<template>
  <!-- header -->
  <header class="header header-dark bg-dark header-sticky">
    <div class="container">
      <div class="row">
        <!-- navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark">
          <a href="index.html" class="navbar-brand order-1 order-lg-2"
            ><img src="../../assets/images/modpack_logo.svg" alt="Logo"
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
                <a href="/Home/FeaturedProducts" class="nav-link">精選商品</a>
              </li>
              <!-- 所有主包 -->
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#!"
                  id="navbarDropdown-11"
                  role="button"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  >所有主包</a
                >
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown-11">
                  <li>
                    <a href="/Home/StudentPackages" class="dropdown-item"
                      >學生包</a
                    >
                  </li>
                  <li>
                    <a href="/Home/OfficePackages" class="dropdown-item"
                      >辦公包</a
                    >
                  </li>
                </ul>
              </li>
              <!-- 所有配件 -->
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#!"
                  id="navbarDropdown-12"
                  role="button"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  >所有配件</a
                >
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown-12">
                  <li>
                    <a href="/Home/StudentAccessories" class="dropdown-item"
                      >學生包</a
                    >
                  </li>
                  <li>
                    <a href="/Home/GeneralAccessories" class="dropdown-item"
                      >通用包</a
                    >
                  </li>
                </ul>
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
                <a href="/Home/CustomizedBags" class="nav-link">客製化包包</a>
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
                <a href="/Account/Login" class="nav-link">Log In</a>
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
                >
                  Michael
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown-10">
                  <li><a class="dropdown-item" href="">Profile</a></li>
                  <li>
                    <router-link to="/profile_order" class="dropdown-item"
                      >Orders</router-link
                    >
                  </li>
                  <li>
                    <a class="dropdown-item" href="profile-addresses.html"
                      >Addresses</a
                    >
                  </li>
                  <li>
                    <a class="dropdown-item" href="profile-payments.html"
                      >Payments</a
                    >
                  </li>
                  <li>
                    <a class="dropdown-item" href="profile-wishlist.html"
                      >Wishlist</a
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
                <RouterLink
                  to="/cart"
                  data-toggle="modal"
                  data-target="#cart"
                  class="nav-link"
                  ><span>購物車</span></RouterLink
                >
              </li>
            </ul>
          </div>
        </nav>
      </div>
    </div>
  </header>
</template>
<script>
export default {};
</script>
<style></style>
