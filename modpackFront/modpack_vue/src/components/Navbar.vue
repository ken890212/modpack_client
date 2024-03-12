<template>
  <!-- header -->
  <header class="header header-dark bg-dark header-sticky">
    <div class="container">
      <div class="row">
        <!-- navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark">
          <a :href="`${MVC_URL}`" class="navbar-brand order-1 order-lg-2"
            ><img :src="`${IMG_URL}/modpack_logo.svg`" alt="Logo"
          /></a>
          <button
            class="navbar-toggler order-2"
            type="button"
            data-toggle="collapse"
            data-target=".navbar-collapse"
            aria-controls="navbarMenu"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>

          <div
            class="collapse navbar-collapse order-3 order-lg-1"
            id="navbarMenu"
          >
            <ul class="navbar-nav mr-auto">
              <!-- 精選商品 -->
              <li class="nav-item">
                <router-link to="/product_listing" class="nav-link"
                  >精選商品</router-link
                >
              </li>
              <!-- 限時優惠 -->
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#!"
                  id="navbarDropdown-13"
                  role="button"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  >限時優惠</a
                >
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown-13">
                  <li>
                    <a href="/Home/DiscountedProducts" class="dropdown-item"
                      >9折商品</a
                    >
                  </li>
                  <li>
                    <a href="/Home/BackToSchoolDiscount" class="dropdown-item"
                      >開學特惠</a
                    >
                  </li>
                </ul>
              </li>
              <li class="nav-item">
                <router-link to="./custom_listing" class="nav-link"
                  >客製化背包</router-link
                >
              </li>
            </ul>
          </div>

          <div
            class="collapse navbar-collapse order-4 order-lg-3"
            id="navbarMenu2"
          >
            <ul class="navbar-nav ml-auto">
              <!-- 登入 -->
              <li class="nav-item">
                <a :href="`${MVC_URL}/Authentication/Logout`" class="nav-link"
                  >登出</a
                >
              </li>
              <!-- 會員資料 -->
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#!"
                  id="navbarDropdown-10"
                  role="button"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  >{{ memberInfo.name }}
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown-10">
                  <li>
                    <a
                      class="dropdown-item"
                      :href="`${MVC_URL}/UserProfile/Profile`"
                      >基本資料</a
                    >
                  </li>
                  <li>
                    <router-link to="/profile_order" class="dropdown-item"
                      >訂單</router-link
                    >
                  </li>
                  <li>
                    <a class="dropdown-item" href="profile-wishlist.html"
                      >收藏</a
                    >
                  </li>
                </ul>
              </li>
              <!-- 搜尋 -->
              <li class="nav-item">
                <a data-toggle="modal" data-target="#search" class="nav-link"
                  ><i class="icon-search"></i
                ></a>
              </li>
              <!-- 購物車 -->
              <li class="nav-item cart">
                <a data-toggle="modal" data-target="#cart" class="nav-link"
                  ><span>購物車</span></a
                >
              </li>
            </ul>
          </div>
        </nav>
      </div>
    </div>
  </header>
  <!-- 購物車 -->
  <div
    class="modal fade sidebar"
    id="cart"
    tabindex="-1"
    role="dialog"
    aria-labelledby="cartLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="cartLabel">購物車</h5>
          <button
            type="button"
            class="close"
            data-dismiss="modal"
            aria-label="Close"
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <p>{{ cartItems }}</p>
          <div class="row gutter-3" v-for="item in cartItems">
            <div class="col-12">
              <div class="cart-item cart-item-sm">
                <div class="row align-items-center">
                  <div class="col-lg-9">
                    <div class="media media-product">
                      <a href="#!"
                        ><img
                          :src="`${IMG_URL}/${item.imageFile}/${item.imageFileName}`"
                          alt="Image"
                      /></a>
                      <div class="media-body">
                        <h5 class="media-title">
                          {{ item.name }}
                        </h5>
                      </div>
                    </div>
                  </div>
                  <div class="col-lg-3 text-center text-lg-right">
                    <span class="cart-item-price">{{ item.price }}</span>
                  </div>
                  <a href="#!" class="cart-item-close" @click=""
                    ><i class="icon-x"></i
                  ></a>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <div class="container-fluid">
            <div class="row gutter-0">
              <div class="col d-none d-md-block">
                <router-link
                  to="/cart"
                  class="btn btn-lg btn-block btn-secondary"
                  >檢視購物車</router-link
                >
              </div>
              <div class="col">
                <router-link
                  to="/checkout"
                  class="btn btn-lg btn-block btn-primary"
                  >下單</router-link
                >
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
const API_URL = import.meta.env.VITE_API_URL;
export default {
  data() {
    return {
      MVC_URL: import.meta.env.VITE_MVC_URL,
      IMG_URL: import.meta.env.VITE_IMAGE_URL,
      cartItems: [],
      memberId: "",
      memberInfo: [],
    };
  },
  methods: {
    async fetchCartItems() {
      await new Promise((resolve, reject) => {
        setTimeout(resolve, 3000);
      });
      try {
        const response = await fetch(`${API_URL}/Carts/${this.memberId}`);
        const data = await response.json();
        console.log(data);
        console.log(this.cartItems);
        this.cartItems.splice(0, this.cartItems.length);
        this.cartItems.push(...data);
        console.log(this.cartItems);
      } catch (error) {
        console.error("Error fetching cart data:", error);
      }
    },
    async fetchMemberInfo() {
      try {
        const response = await fetch(`${API_URL}/Members/${this.memberId}`);
        const memberData = await response.json();
        console.log(memberData);
        this.memberInfo = memberData;
      } catch (error) {
        console.log("Error fetching memberInfo", error);
      }
    },
    getMemberIdFromCookie() {
      const match = document.cookie.match(/(?:^|;) ?memberId=([^;]*)(?:;|$)/);
      if (match) {
        this.memberId = match[1];
      }
    },
  },
  mounted() {
    this.getMemberIdFromCookie();
    this.fetchMemberInfo();
    this.fetchCartItems();
  },
};
</script>
<style></style>
