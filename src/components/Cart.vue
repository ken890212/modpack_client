<template>
  <!-- hero -->
  <section class="hero">
    <div class="container">
      <div class="row">
        <div class="col text-center">
          <h1>購物車</h1>
        </div>
      </div>
    </div>
  </section>

  <section class="pt-0">
    <div class="container">
      <div class="row mb-0 d-none d-lg-flex">
        <div class="col">
          <div class="row pr-6">
            <div class="col-lg-6"><span class="eyebrow">產品名稱</span></div>
            <div class="col-lg-2 text-center">
              <span class="eyebrow">單價</span>
            </div>
            <div class="col-lg-2 text-center">
              <span class="eyebrow">數量</span>
            </div>
            <div class="col-lg-2 text-center">
              <span class="eyebrow">小計</span>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col cart-item-list cart-item-list-minimal">
          <!-- cart item -->
          <div class="cart-item" v-for="item in cartItems" :key="item.cartId">
            <div class="row align-items-center">
              <div class="col-12 col-lg-6">
                <div class="media media-product">
                  <a href="#!"
                    ><img
                      :src="`${IMG_URL}/${item.imageFile}/${item.imageFileName}`"
                      alt="Image"
                  /></a>
                  <div class="media-body">
                    <h5 class="media-title">{{ item.name }}</h5>
                  </div>
                </div>
              </div>
              <div class="col-4 col-lg-2 text-center">
                <span class="cart-item-price">{{ item.price }}</span>
              </div>
              <div class="col-4 col-lg-2 text-center">
                <div class="counter">
                  <!-- 產品數量-1 -->
                  <span
                    class="counter-minus icon-minus"
                    @click="decQuantity(item)"
                  ></span>
                  <!-- 產品數量修改 -->
                  <input
                    type="text"
                    name="qty-1"
                    class="counter-value"
                    v-model="item.quantity"
                    @input="updateQuantity(item)"
                    min="1"
                    max="10"
                  />
                  <!-- 產品數量+1 -->
                  <span
                    class="counter-plus icon-plus"
                    @click="incQuantity(item)"
                  ></span>
                </div>
              </div>
              <div class="col-4 col-lg-2 text-center">
                <span class="cart-item-price">{{
                  item.price * item.quantity
                }}</span>
              </div>
              <!-- 刪除產品按鈕 -->
              <a href="#!" class="cart-item-close" @click="deleteProduct(item)"
                ><i class="icon-x"></i
              ></a>
            </div>
          </div>
        </div>
      </div>
      <div class="row justify-content-between">
        <div class="col-md-6 col-lg-4">
          <div class="inline-block">
            <span class="eyebrow">總計</span>
            <h4 class="h2">{{ totalPrice }}</h4>
          </div>
        </div>
        <div class="col-md-6 col-lg-4">
          <!-- <div class="input-group">
            <input
              type="text"
              class="form-control"
              placeholder="Coupon Code"
              aria-label="Coupon"
            />
            <div class="input-group-append">
              <button type="button" class="btn btn-secondary btn-ico">
                <i class="icon-arrow-right"></i>
              </button>
            </div>
          </div> -->
          <router-link
            to="/checkout"
            class="btn btn-lg btn-primary btn-block mt-1"
            >下單</router-link
          >
        </div>
      </div>
    </div>
  </section>

  <!-- bootstrap 提視窗 -->
  <div class="modal" id="deleteProductSuccess" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <p>產品成功移除購物車</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            關閉
          </button>
        </div>
      </div>
    </div>
  </div>
  <div class="modal" id="deleteProductFailed" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <p>產品移除購物車失敗</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            關閉
          </button>
        </div>
      </div>
    </div>
  </div>
  <div class="modal" id="cartEmpty" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <p>購物車為空，請先購物</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            關閉
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
const API_URL = import.meta.env.VITE_API_URL;
import NavbarMixin from "./Navbar.vue";
export default {
  mixins: [NavbarMixin],
  data() {
    return {
      MVC_URL: import.meta.env.VITE_MVC_URL,
      IMG_URL: import.meta.env.VITE_IMAGE_URL,
      cartItems: [],
      totalPrice: 0,
      memberId: "",
    };
  },
  methods: {
    async fetchCartItems() {
      try {
        const response = await fetch(`${API_URL}/Carts/${this.memberId}`);
        if (response.status == 200) {
          const data = await response.json();
          console.log(data);
          this.cartItems = data;
          this.updateTotalPrice();
        } else {
          this.CartEmpty();
        }
      } catch (error) {
        console.error("Error fetching cart data:", error);
      }
    },
    async deleteProduct(item) {
      try {
        const response = await fetch(`${API_URL}/Carts/${item.cartId}`, {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        });

        if (response.ok) {
          this.fetchCartItems();
          $("#deleteProductSuccess").modal("show");
        } else {
          console.error("刪除失敗:", response.statusText);
          $("deleteProductFailed").modal("show");
        }
      } catch (error) {
        console.error("刪除失敗:", error);
      }
    },
    incQuantity(item) {
      if (item.quantity < 10) {
        // 限制最大值為10，根據需求調整
        item.quantity++;
        this.updateCartQuantity(item);
      }
    },
    decQuantity(item) {
      if (item.quantity > 1) {
        // 限制最小值為1，根據需求調整
        item.quantity--;
        this.updateCartQuantity(item);
      }
    },
    updateQuantity(item) {
      item.quantity = parseInt(item.quantity);
      this.updateCartQuantity(item);
    },
    updateTotalPrice() {
      this.totalPrice = this.cartItems.reduce(
        (accumulator, item) => accumulator + item.price * item.quantity,
        0
      );
    },
    async updateCartQuantity(item) {
      try {
        const response = await fetch(`${API_URL}/Carts/${item.cartId}`, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            cartId: item.cartId,
            quantity: item.quantity,
            imageFileName: item.imageFileName,
          }),
        });
        const result = await response.text();
        if (response.ok) {
          this.updateTotalPrice();
          console.log("Update quantity successful:", result);
        } else {
          console.log("Error updating quantity:", result);
        }
      } catch (error) {
        console.error("Error updating quantity:", error);
      }
    },
    CartEmpty() {
      $("#deleteProductSuccess").modal("hide");
      $("#cartEmpty")
        .modal("show")
        .on("hidden.bs.modal", () => {
          this.$router.push("/product_listing");
        });
    },
  },
  mounted() {
    this.getMemberIdFromCookie();
    this.fetchCartItems();
  },
};
</script>
<style></style>
