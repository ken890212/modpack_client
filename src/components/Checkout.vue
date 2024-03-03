<template>
  <!-- breadcrumbs -->
  <section class="breadcrumbs separator-bottom">
    <div class="container">
      <div class="row">
        <div class="col">
          <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item">
                <a href="#">Shop</a>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                Checkout
              </li>
            </ol>
          </nav>
        </div>
      </div>
    </div>
  </section>

  <!-- hero -->
  <section>
    <div class="container">
      <div class="row">
        <div class="col text-center">
          <h1>Checkout</h1>
        </div>
      </div>
    </div>
  </section>

  <section class="no-overflow pt-0">
    <div class="container">
      <div class="row gutter-4 justify-content-between">
        <div class="col-lg-8">
          <!-- delivery -->
          <div class="row align-items-end mb-2">
            <div class="col-md-6">
              <h2 class="h3 mb-0">
                <span class="text-muted">01.</span> 寄送資訊
              </h2>
            </div>
            <div class="col-md-6 text-md-right">
              <a
                class="eyebrow unedrline action"
                data-toggle="modal"
                data-target="#addresses"
                >My Addresses</a
              >
            </div>
          </div>
          <div class="row gutter-1 mb-6">
            <div class="form-group col-md-12">
              <label for="RecipientName">收件人姓名</label>
              <input
                v-model="recipientName"
                type="text"
                class="form-control"
                id="RecipientName"
                placeholder="請輸入姓名"
              />
            </div>

            <div class="form-group col-md-12">
              <label for="RecipientAddress">收件人地址</label>
              <input
                v-model="recipientAddress"
                type="text"
                class="form-control"
                id="RecipientAddress"
                placeholder="請輸入地址"
              />
            </div>

            <!-- 帳單收件人 -->
            <div class="form-group col-md-12">
              <label for="BillRecipientName">帳單收件人姓名</label>
              <input
                v-model="billRecipientName"
                type="text"
                class="form-control"
                id="BillRecipientName"
                placeholder="請輸入姓名"
              />
            </div>

            <div class="form-group col-md-12">
              <label for="BillRecipientAddress">帳單收件人地址</label>
              <input
                v-model="billRecipientAddress"
                type="text"
                class="form-control"
                id="BillRecipientAddress"
                placeholder="請輸入地址"
              />
            </div>
          </div>

          <!-- 寄送方式 -->
          <div class="row align-items-end mb-2">
            <div class="col-md-6">
              <h2 class="h3 mb-0">
                <span class="text-muted">02.</span> 寄送方式
              </h2>
            </div>
          </div>
          <div class="row gutter-1">
            <div
              class="col-md-6"
              v-for="shipping in shippingMethods"
              :key="shipping.shippingId"
            >
              <div class="custom-control custom-choice">
                <input
                  type="radio"
                  :id="'choice-shipping-' + shipping.shippingId"
                  :name="'choice-shipping-' + shipping.shippingId"
                  :value="shipping.shippingId"
                  v-model="selectedShippingMethod"
                  class="custom-control-input"
                />
                <label
                  class="custom-control-label text-dark"
                  :for="'choice-shipping-' + shipping.shippingId"
                >
                  <span class="d-flex justify-content-between mb-1 eyebrow"
                    >{{ shipping.description }}
                    <span class="text-muted"
                      >${{ shipping.deliveryCost }}</span
                    ></span
                  >
                  寄送描述
                </label>
                <span class="choice-indicator"></span>
              </div>
            </div>
          </div>
        </div>
        <aside class="col-lg-4">
          <div class="row">
            <!-- order preview -->
            <div class="col-12">
              <div class="card card-data bg-light">
                <div class="card-header py-2 px-3">
                  <div class="row align-items-center">
                    <div class="col">
                      <h3 class="fs-18 mb-0">購物車</h3>
                    </div>
                    <div class="col text-right">
                      <a href="#" class="underline eyebrow">Edit</a>
                    </div>
                  </div>
                </div>
                <div class="card-body">
                  <ul class="list-group list-group-line">
                    <li
                      v-for="item in cartItems"
                      :key="item.cartId"
                      class="list-group-item d-flex justify-content-between text-dark align-items-center"
                    >
                      {{ item.name }} x {{ item.quantity }}
                      <span>$ {{ item.price * item.quantity }}</span>
                    </li>
                  </ul>
                </div>
              </div>
            </div>

            <!-- order summary -->
            <div class="col-12 mt-1">
              <div class="card card-data bg-light">
                <div class="card-header py-2 px-3">
                  <div class="row align-items-center">
                    <div class="col">
                      <h3 class="fs-18 mb-0">訂單資訊</h3>
                    </div>
                  </div>
                </div>
                <div class="card-body">
                  <ul class="list-group list-group-minimal">
                    <li
                      class="list-group-item d-flex justify-content-between align-items-center"
                    >
                      小計
                      <span> {{ totalPrice }}</span>
                    </li>
                    <li
                      class="list-group-item d-flex justify-content-between align-items-center"
                    >
                      運費
                      <span>{{ shipping.deliveryCost }}</span>
                    </li>
                    <!-- <li
                      class="list-group-item d-flex justify-content-between align-items-center"
                    >
                      折扣
                      <span>-25%</span>
                    </li> -->
                  </ul>
                </div>
                <div class="card-footer py-2">
                  <ul class="list-group list-group-minimal">
                    <li
                      class="list-group-item d-flex justify-content-between align-items-center text-dark fs-18"
                    >
                      總計
                      <span>{{ shipping.deliveryCost + totalPrice }}</span>
                    </li>
                  </ul>
                </div>
              </div>
            </div>

            <!-- place order -->
            <div class="col-12 mt-1">
              <a
                @click="placeOrder"
                href="#!"
                class="btn btn-primary btn-lg btn-block"
                >Place Order</a
              >
            </div>
          </div>
        </aside>
      </div>
    </div>
  </section>
</template>
<script>
var baseAddress = "http://localhost:7250";
export default {
  data() {
    return {
      recipientName: "",
      recipientAddress: "",
      billRecipientName: "",
      billRecipientAddress: "",
      shippingMethods: [],
      selectedShippingMethod: null,
      cartItems: [],
      totalPrice: 0,
      shipping: {},
    };
  },
  methods: {
    async fetchShippingMethods() {
      try {
        const response = await fetch(`${baseAddress}/api/Shippings`, {
          method: "GET",
        });

        if (response.ok) {
          const data = await response.json();

          this.shippingMethods = data;
          // 給預設值
          this.selectedShippingMethod = data[0].shippingId;
          //更新 shipping 變數
          this.shipping = data[0];
          // console.log(data);
        } else {
          console.error("Failed to fetch shipping methods");
        }
      } catch (err) {
        console.error(err);
      }
    },
    async fetchCartItems() {
      try {
        //memberId 要改登入會員id
        const memberId = 1;
        const response = await fetch(`${baseAddress}/api/Carts/${memberId}`);
        const data = await response.json();

        this.cartItems = data;
        this.totalPrice = data.reduce(
          (accumulator, item) => accumulator + item.price * item.quantity,
          0
        );
        //console.log(data);
      } catch (error) {
        console.error("Error fetching cart data:", error);
      }
    },

    //提交訂單
    async placeOrder() {
      try {
        // 檢查姓名和地址是否為空
        if (!this.recipientName || !this.recipientAddress) {
          alert("請輸入完整的姓名和地址");
          return;
        }
        // 檢查是否選擇了寄送方式
        if (!this.selectedShippingMethod) {
          alert("請選擇寄送方式");
          return;
        }

        //要發送的資料
        var orderData = {
          orderId: 0,
          memberId: 1,
          paymentStatusId: 1,
          paymentId: 1,
          promoCodeId: 1,
          recipientName: this.recipientName,
          recipientAddress: this.recipientAddress,
          billRecipientName: this.billRecipientName,
          billRecipientAddress: this.billRecipientAddress,
          shippingId: this.selectedShippingMethod,
          shippingStatusId: 1,
          orderStatusId: 1,
          creationTime: dateTimeNow,
        };

        const response = await fetch(`${baseAddress}/api/Orders`, {
          method: "POST",
          body: JSON.stringify(orderData),
          headers: {
            "content-type": "application/json",
          },
        });
        if (response.ok) {
          const data = await response.json();
          this.showAlert("訂單提交成功");
        } else {
          throw new Error("訂單提交失敗");
        }
      } catch (error) {
        this.showAlert("訂單提交失敗：" + error.message);
        console.error("訂單提交失敗", error);
      }
    },
  },
  watch: {
    selectedShippingMethod: function (newVal) {
      const selectedShipping = this.shippingMethods.find(
        (shipping) => shipping.shippingId === newVal
      );
      if (selectedShipping) {
        // 更新 shipping 變數
        this.shipping = selectedShipping;
      }
    },
  },
  mounted() {
    this.fetchShippingMethods();
    this.fetchCartItems();
  },
  components: {},
};
</script>
<style></style>
