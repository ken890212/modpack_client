<template>
  <!-- hero -->
  <section class="hero">
    <div class="container">
      <div class="row">
        <div class="col text-center">
          <h1>Your Cart</h1>
        </div>
      </div>
    </div>
  </section>

  <section class="pt-0">
    <div class="container">
      <div class="row mb-0 d-none d-lg-flex">
        <div class="col">
          <div class="row pr-6">
            <div class="col-lg-6"><span class="eyebrow">Product</span></div>
            <div class="col-lg-2 text-center">
              <span class="eyebrow">Price</span>
            </div>
            <div class="col-lg-2 text-center">
              <span class="eyebrow">Quantity</span>
            </div>
            <div class="col-lg-2 text-center">
              <span class="eyebrow">Total</span>
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
                      src="../../assets/' + item.ImageFileName + '.jpg'"
                      alt="Image"
                  /></a>
                  <div class="media-body">
                    <h5 class="media-title">{{ getItemName(item) }}</h5>
                  </div>
                </div>
              </div>
              <div class="col-4 col-lg-2 text-center">
                <span class="cart-item-price">{{ getItemPrice(item) }}</span>
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
                  getItemPrice(item) * item.quantity
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
            <span class="eyebrow">Total</span>
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
            >Checkout</router-link
          >
        </div>
      </div>
    </div>
  </section>
</template>
<script>
var baseAddress = "http://localhost:7250";
export default {
  data() {
    return {
      cartItems: [],
      totalPrice: 0,
    };
  },
  methods: {
    async fetchCartItems() {
      try {
        //memberId 要改登入會員id
        const memberId = 1;
        const response = await fetch(`${baseAddress}/api/Carts/${memberId}`);
        const data = await response.json();

        this.cartItems = data;
        this.updateTotalPrice();
        //console.log(data);
      } catch (error) {
        console.error("Error fetching cart data:", error);
      }
    },
    getItemName(item) {
      if (item.productName !== "") {
        return `${item.productName}`;
      } else if (item.inspirationName !== "") {
        return `${item.inspirationName}`;
      } else if (item.customizedName !== "") {
        return `${item.customizedName}`;
      } else {
        return "找不到產品";
      }
    },
    getItemPrice(item) {
      if (item.productprice !== 0) {
        return item.productprice;
      } else if (item.inspirationprice !== 0) {
        return item.inspirationprice;
      } else if (item.customizedprice !== 0) {
        return item.customizedprice;
      } else {
        return 0;
      }
    },
    async deleteProduct(item) {
      try {
        const response = await fetch(
          `${baseAddress}/api/Carts/${item.cartId}`,
          {
            method: "DELETE",
            headers: {
              "Content-Type": "application/json",
            },
          }
        );

        if (response.ok) {
          this.fetchCartItems();
        } else {
          console.error("Error deleting product:", response.statusText);
        }
      } catch (error) {
        console.error("Error deleting product:", error);
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
        (accumulator, item) =>
          accumulator + this.getItemPrice(item) * item.quantity,
        0
      );
    },

    async updateCartQuantity(item) {
      try {
        const response = await fetch(
          `${baseAddress}/api/Carts/${item.cartId}`,
          {
            method: "PUT",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              cartId: item.cartId,
              quantity: item.quantity,
            }),
          }
        );
        if (response.ok) {
          this.updateTotalPrice();
        } else {
          console.log("Error deleting product:", response.statusText);
        }
      } catch (error) {
        console.error("Error updating quantity:", error);
      }
    },
  },
  mounted() {
    this.fetchCartItems();
  },
};
</script>
<style></style>
