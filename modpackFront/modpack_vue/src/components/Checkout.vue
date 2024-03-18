<template>
  <!-- breadcrumbs -->
  <section class="breadcrumbs separator-bottom">
    <div class="container">
      <div class="row">
        <div class="col">
          <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
              <li class="breadcrumb-item"><a :href="`${MVC_URL}`">首頁</a></li>
              <li class="breadcrumb-item">
                <router-link to="/cart">購物車</router-link>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                下單頁面
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
          <h1>下單頁面</h1>
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
                >我的資訊</a
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

            <!-- 會員資訊 -->
            <!-- <div
              class="modal sidebar fade"
              id="addresses"
              tabindex="-1"
              role="dialog"
              aria-labelledby="addressesLabel"
              aria-hidden="true"
            >
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="addressesLabel">我的資訊</h5>
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
                    <div class="row gutter-3">
                      <div class="col-12">
                        <div class="custom-control custom-choice">
                          <input
                            type="radio"
                            name="choiceRadio"
                            class="custom-control-input"
                            id="customChoice1"
                          />
                          <label
                            class="custom-control-label text-dark"
                            for="customChoice1"
                          >
                            姓名：{{ memberInfo.name }} <br />
                            地址：{{ memberInfo.address }}
                          </label>
                          <span class="choice-indicator"></span>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div> -->

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
                >前往付款</a
              >
            </div>
          </div>
        </aside>
      </div>
    </div>
  </section>

  <!-- Bootstrap 提視窗 -->
  <div class="modal" id="orderSuccess" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <p>下單成功</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            關閉
          </button>
        </div>
      </div>
    </div>
  </div>

  <div class="modal" id="orderFailed" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-body">
          <p>下單失敗</p>
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
      recipientName: "",
      recipientAddress: "",
      billRecipientName: "",
      billRecipientAddress: "",
      shippingMethods: [],
      selectedShippingMethod: null,
      cartItems: [],
      memberInfo: [],
      totalPrice: 0,
      shipping: {},
      memberId: "",
    };
  },
  methods: {
    async fetchShippingMethods() {
      try {
        const response = await fetch(`${API_URL}/Shippings`, {
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
        const response = await fetch(`${API_URL}/Carts/${this.memberId}`);
        const data = await response.json();

        this.cartItems = data;
        this.totalPrice = data.reduce(
          (accumulator, item) => accumulator + item.price * item.quantity,
          0
        );
        console.log(data);
      } catch (error) {
        console.error("Error fetching cart data:", error);
      }
    },

    //提交訂單
    async placeOrder() {
      try {
        // 檢查姓名和地址是否為空
        if (this.recipientName == "") {
          alert("請輸入完整的姓名和地址");
          return;
        }
        // 檢查是否選擇了寄送方式
        if (!this.selectedShippingMethod) {
          alert("請選擇寄送方式");
          return;
        }

        const currentDateTime = new Date();
        const DateTime = new Date(
          currentDateTime.getTime() + 8 * 60 * 60 * 1000
        );

        //要發送的資料
        var orderData = {
          orderId: 0,
          memberId: this.memberId,
          paymentStatusId: 1,
          paymentId: 1,
          promoCodeId: 1,
          shippingId: this.selectedShippingMethod,
          recipientName: this.recipientName,
          recipientAddress: this.recipientAddress,
          billRecipientName: this.billRecipientName,
          billRecipientAddress: this.billRecipientAddress,
          shippingStatusId: 1,
          creationTime: DateTime.toISOString(),
          completionTime: null,
          orderStatusId: 1,
        };

        const response = await fetch(`${API_URL}/Orders`, {
          method: "POST",
          body: JSON.stringify(orderData),
          headers: {
            "content-type": "application/json",
          },
        });

        if (response.ok) {
          const data = await response.json();
          console.log(data);
          $("orderSuccess").modal("show");
          await this.submitOrderDetails(data);
        } else {
          $("orderFailed").modal("show");
        }
      } catch (error) {
        console.error("訂單提交失敗", error.message);
      }
    },

    async submitOrderDetails(data) {
      const orderDetailsData = [];
      for (const item of this.cartItems) {
        const detail = {
          orderId: data.orderId,
          productId: item.productId || null,
          inspirationId: item.inspirationId || null,
          customizedId: item.customizedId || null,
          quantity: item.quantity,
          unitPrice: item.price,
        };
        console.log("OrderDetail JSON data:", detail);
        orderDetailsData.push(detail);
      }

      const detailsResponse = await fetch(`${API_URL}/OrderDetails`, {
        method: "POST",
        body: JSON.stringify(orderDetailsData),
        headers: {
          "content-type": "application/json",
        },
      });

      if (detailsResponse.ok) {
        console.log("OrderDetails 建立成功");
        //建立成功 刪除購物車所有內容
        await this.clearCarts(data.memberId);
      } else {
        const detailsErrorMessage = await detailsResponse.text();
        console.log("OrderDetails 建立失敗：" + detailsErrorMessage);
        //如果details 建立失敗，要刪除前面建立的訂單
      }
    },
    async clearCarts(memberId) {
      const clearResponse = await fetch(`${API_URL}/Carts/Clear${memberId}`, {
        method: "DELETE",
        headers: {
          "content-type": "application/json",
        },
      });
      if (clearResponse.ok) {
        console.log("購物車清空成功");
      } else {
        console.log("購物車清空失敗");
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
    this.getMemberIdFromCookie();
    this.fetchShippingMethods();
    this.fetchCartItems();
    this.fetchMemberInfo();
  },
  components: {},
};
</script>
<style></style>
