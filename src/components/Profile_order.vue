<template>
  <!-- hero -->
  <section class="hero hero-small bg-gray text-white">
    <div class="container">
      <div class="row gutter-2 gutter-md-4 align-items-end">
        <div class="col-md-6 text-center text-md-left">
          <h1 class="mb-0">Member Name</h1>
          <span class="text-muted">New York, USA</span>
        </div>
        <div class="col-md-6 text-center text-md-right">
          <a href="#!" class="btn btn-sm btn-outline-white">Sign out</a>
        </div>
      </div>
    </div>
  </section>
  <!-- listing -->
  <section class="pt-5">
    <div class="container">
      <div class="row gutter-4 justify-content-between">
        <!-- sidebar -->
        <aside class="col-lg-3">
          <div
            class="nav nav-pills flex-column lavalamp"
            id="sidebar-1"
            role="tablist"
          >
            <a
              class="nav-link"
              data-toggle="tab"
              href="#sidebar-1-1"
              role="tab"
              aria-controls="sidebar-1"
              aria-selected="false"
              >Profile</a
            >
            <a
              class="nav-link active"
              data-toggle="tab"
              href="#sidebar-1-2"
              role="tab"
              aria-controls="sidebar-1-2"
              aria-selected="true"
              >Orders</a
            >
            <a
              class="nav-link"
              data-toggle="tab"
              href="#sidebar-1-3"
              role="tab"
              aria-controls="sidebar-1-3"
              aria-selected="false"
              >Addresses</a
            >
            <a
              class="nav-link"
              data-toggle="tab"
              href="#sidebar-1-4"
              role="tab"
              aria-controls="sidebar-1-4"
              aria-selected="false"
              >Payments</a
            >
            <a
              class="nav-link"
              data-toggle="tab"
              href="#sidebar-1-5"
              role="tab"
              aria-controls="sidebar-1-5"
              aria-selected="false"
              >Wishlist</a
            >
          </div>
        </aside>
        <!-- / sidebar -->

        <!-- content -->
        <div class="col-lg-9">
          <div class="row">
            <div class="col">
              <div class="tab-content" id="myTabContent">
                <!-- profile -->
                <!-- <div
                  class="tab-pane fade"
                  id="sidebar-1-1"
                  role="tabpanel"
                  aria-labelledby="sidebar-1-1"
                >
                  <div class="row mb-2">
                    <div class="col-12">
                      <h3>Personal Data</h3>
                    </div>
                  </div>
                  <div class="row gutter-1">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput1">First Name</label>
                        <input
                          id="exampleInput1"
                          type="text"
                          class="form-control"
                          placeholder="First name"
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput2">Last Name</label>
                        <input
                          id="exampleInput2"
                          type="text"
                          class="form-control"
                          placeholder="Last name"
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput3">Company</label>
                        <input
                          id="exampleInput3"
                          type="text"
                          class="form-control"
                          placeholder="Company"
                        />
                      </div>
                    </div>
                    <div class="col-md-3">
                      <div class="form-group">
                        <label for="exampleInput4">Street</label>
                        <input
                          id="exampleInput4"
                          type="text"
                          class="form-control"
                          placeholder="Street"
                        />
                      </div>
                    </div>
                    <div class="col-md-3">
                      <div class="form-group">
                        <label for="exampleInput5">Zip</label>
                        <input
                          id="exampleInput5"
                          type="text"
                          class="form-control"
                          placeholder="Zip"
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput6">Telephone</label>
                        <input
                          id="exampleInput6"
                          type="text"
                          class="form-control"
                          placeholder="Telephone"
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput7">Email</label>
                        <input
                          id="exampleInput7"
                          type="text"
                          class="form-control"
                          placeholder="Email"
                        />
                      </div>
                    </div>
                  </div>

                  <div class="row mb-2 mt-6">
                    <div class="col-12">
                      <h3>Password</h3>
                    </div>
                  </div>
                  <div class="row gutter-1">
                    <div class="col-12">
                      <div class="form-group">
                        <label for="exampleInput8">Old Password</label>
                        <input
                          id="exampleInput8"
                          type="password"
                          class="form-control"
                          placeholder="Password"
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput9">New Password</label>
                        <input
                          id="exampleInput9"
                          type="password"
                          class="form-control"
                          placeholder="Password"
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="exampleInput10">Retype New Password</label>
                        <input
                          id="exampleInput10"
                          type="password"
                          class="form-control"
                          placeholder="Password"
                        />
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col">
                      <a href="#!" class="btn btn-primary">Save Changes</a>
                    </div>
                  </div>
                </div> -->

                <!-- orders -->
                <div
                  class="tab-pane fade show active"
                  id="sidebar-1-2"
                  role="tabpanel"
                  aria-labelledby="sidebar-1-2"
                >
                  <div class="row">
                    <div class="col-12">
                      <h3 class="mb-0">Orders</h3>
                      <span class="eyebrow">{{ orders.length }} Items</span>
                    </div>
                  </div>
                  <div
                    v-for="order in orders"
                    :key="order.orderId"
                    class="row gutter-2"
                  >
                    <div class="col-12">
                      <div class="order">
                        <div class="row align-items-center">
                          <div class="col-lg-4">
                            <!-- 訂單編號 -->
                            <h3 class="order-number">
                              訂單編號 {{ order.orderId }}
                            </h3>
                            <a href="#!" class="action eyebrow underline"
                              >View Order</a
                            >
                          </div>
                          <div class="col-lg-4">
                            <span class="order-status sent">{{
                              order.orderStatusName
                            }}</span>
                          </div>
                          <div class="col-lg-4">
                            <ul class="order-preview justify-content-end">
                              <li
                                v-if="orderDetails[order.orderId]"
                                v-for="detail in orderDetails[order.orderId]"
                                :key="detail.detailsId"
                              >
                                <a
                                  href="javascript:;"
                                  :title="detail.name"
                                  data-toggle="tooltip"
                                  data-placement="top"
                                >
                                  <img
                                    src="../../assets/' + detail.ImageFileName + '.jpg'"
                                    alt="image"
                                /></a>
                              </li>
                            </ul>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <!-- pagination -->
                  <div class="row">
                    <div class="col">
                      <ul class="pagination">
                        <li class="page-item active">
                          <a class="page-link" href="#!"
                            >1 <span class="sr-only">(current)</span></a
                          >
                        </li>
                        <li class="page-item" aria-current="page">
                          <a class="page-link" href="#!">2</a>
                        </li>
                        <li class="page-item">
                          <a class="page-link" href="#!">3</a>
                        </li>
                        <li class="page-item">
                          <a class="page-link" href="#!">4</a>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>

                <!-- addresses -->
                <!-- <div
                  class="tab-pane fade"
                  id="sidebar-1-3"
                  role="tabpanel"
                  aria-labelledby="sidebar-1-3"
                >
                  <div class="row">
                    <div class="col">
                      <h3 class="mb-0">Addresses</h3>
                      <span class="eyebrow">2 Entry</span>
                    </div>
                  </div>
                  <div class="row gutter-2">
                    <div class="col-md-6">
                      <div class="card card-data">
                        <div class="card-header card-header-options">
                          <div class="row align-items-center">
                            <div class="col">
                              <h3 class="card-title">Address 1</h3>
                            </div>
                            <div class="col text-right">
                              <div class="dropdown">
                                <button
                                  id="dropdownMenuButton"
                                  data-toggle="dropdown"
                                  aria-haspopup="true"
                                  aria-expanded="false"
                                  type="button"
                                  class="btn btn-lg btn-secondary btn-ico"
                                >
                                  <i class="icon-more-vertical"></i>
                                </button>
                                <ul
                                  class="dropdown-menu"
                                  aria-labelledby="dropdownMenuButton"
                                >
                                  <li>
                                    <a class="dropdown-item" href="#!">Edit</a>
                                  </li>
                                  <li>
                                    <a class="dropdown-item" href="#!"
                                      >Delete</a
                                    >
                                  </li>
                                </ul>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="card-body w-75">
                          <h5 class="eyebrow text-muted">Where</h5>
                          <p class="card-text">
                            1620 East Ayre Str Suite M3115662 Wilmington, DE
                            19804 United States
                          </p>
                          <h5 class="eyebrow text-muted">To</h5>
                          <p class="card-text">Michael Doe</p>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="card card-data">
                        <div class="card-header card-header-options">
                          <div class="row align-items-center">
                            <div class="col">
                              <h3 class="card-title">Address 2</h3>
                            </div>
                            <div class="col text-right">
                              <div class="dropdown">
                                <button
                                  id="dropdownMenuButton2"
                                  data-toggle="dropdown"
                                  aria-haspopup="true"
                                  aria-expanded="false"
                                  type="button"
                                  class="btn btn-lg btn-secondary btn-ico"
                                >
                                  <i class="icon-more-vertical"></i>
                                </button>
                                <ul
                                  class="dropdown-menu"
                                  aria-labelledby="dropdownMenuButton2"
                                >
                                  <li>
                                    <a class="dropdown-item" href="#!">Edit</a>
                                  </li>
                                  <li>
                                    <a class="dropdown-item" href="#!"
                                      >Delete</a
                                    >
                                  </li>
                                </ul>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="card-body w-75">
                          <h5 class="eyebrow text-muted">Where</h5>
                          <p class="card-text">
                            1620 East Ayre Str Suite M3115662 Wilmington, DE
                            19804 United States
                          </p>
                          <h5 class="eyebrow text-muted">To</h5>
                          <p class="card-text">Michael Doe</p>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col">
                      <h3>New Address</h3>
                    </div>
                  </div>
                  <div class="row gutter-1">
                    <div class="col-12">
                      <div class="form-group">
                        <label for="city">City</label>
                        <input
                          id="city"
                          type="text"
                          class="form-control"
                          placeholder=""
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="cardNumber">Address</label>
                        <input
                          id="cardNumber"
                          type="text"
                          class="form-control"
                          placeholder=""
                        />
                      </div>
                    </div>
                    <div class="col-6 col-md-3">
                      <div class="form-group">
                        <label for="cardNumber2">Nr</label>
                        <input
                          id="cardNumber2"
                          type="text"
                          class="form-control"
                          placeholder=""
                        />
                      </div>
                    </div>
                    <div class="col-6 col-md-3">
                      <div class="form-group">
                        <label for="cardNumber3">Ap</label>
                        <input
                          id="cardNumber3"
                          type="text"
                          class="form-control"
                          placeholder=""
                        />
                      </div>
                    </div>
                    <div class="col-12">
                      <a href="#!" class="btn btn-primary">Add</a>
                    </div>
                  </div>
                </div> -->

                <!-- payments -->
                <!-- <div
                  class="tab-pane fade"
                  id="sidebar-1-4"
                  role="tabpanel"
                  aria-labelledby="sidebar-1-4"
                >
                  <div class="row">
                    <div class="col">
                      <h3 class="mb-0">Payments</h3>
                      <span class="eyebrow">1 Entry</span>
                    </div>
                  </div>
                  <div class="row gutter-2 mb-6">
                    <div class="col-md-6">
                      <div class="card card-data">
                        <div class="card-header card-header-options">
                          <div class="row align-items-center">
                            <div class="col">
                              <h3 class="card-title">Visa</h3>
                            </div>
                            <div class="col text-right">
                              <div class="dropdown">
                                <button
                                  id="dropdownMenu2"
                                  data-toggle="dropdown"
                                  aria-haspopup="true"
                                  aria-expanded="false"
                                  type="button"
                                  class="btn btn-lg btn-secondary btn-ico"
                                >
                                  <i class="icon-more-vertical"></i>
                                </button>
                                <ul
                                  class="dropdown-menu"
                                  aria-labelledby="dropdownMenu2"
                                >
                                  <li>
                                    <a class="dropdown-item" href="#!">Edit</a>
                                  </li>
                                  <li>
                                    <a class="dropdown-item" href="#!"
                                      >Delete</a
                                    >
                                  </li>
                                </ul>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="card-body w-75">
                          <h5 class="eyebrow text-muted">Paymeny Method</h5>
                          <p class="card-text">
                            <b>Visa</b> ends in 1537 Exp: 8/2022
                          </p>
                          <h5 class="eyebrow text-muted">Last Payment</h5>
                          <p class="card-text">
                            <b>$7.00</b> successful on 04/14/2019
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="card card-data">
                        <div class="card-header card-header-options">
                          <div class="row align-items-center">
                            <div class="col">
                              <h3 class="card-title">Paypal</h3>
                            </div>
                            <div class="col text-right">
                              <div class="dropdown">
                                <button
                                  id="dropdownMenu2"
                                  data-toggle="dropdown"
                                  aria-haspopup="true"
                                  aria-expanded="false"
                                  type="button"
                                  class="btn btn-lg btn-secondary btn-ico"
                                >
                                  <i class="icon-more-vertical"></i>
                                </button>
                                <ul
                                  class="dropdown-menu"
                                  aria-labelledby="dropdownMenu2"
                                >
                                  <li>
                                    <a class="dropdown-item" href="#!">Edit</a>
                                  </li>
                                  <li>
                                    <a class="dropdown-item" href="#!"
                                      >Delete</a
                                    >
                                  </li>
                                </ul>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="card-body w-75">
                          <h5 class="eyebrow text-muted">Mail</h5>
                          <p class="card-text">payment@webuildthemes.com</p>
                          <h5 class="eyebrow text-muted">Last Payment</h5>
                          <p class="card-text">
                            <b>$19.00</b> successful on 05/15/2019
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col">
                      <h3 class="mb-0">New Payment Method</h3>
                    </div>
                  </div>
                  <div class="row gutter-1">
                    <div class="col-12">
                      <div class="form-group">
                        <label for="cardNumber">Card Number</label>
                        <input
                          type="text"
                          class="form-control"
                          placeholder=""
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="cardNumber">Name on Card</label>
                        <input
                          type="text"
                          class="form-control"
                          placeholder=""
                        />
                      </div>
                    </div>
                    <div class="col-6 col-md-3">
                      <div class="form-group">
                        <label for="cardNumber">Month</label>
                        <select class="custom-select">
                          <option selected="">Open this select menu</option>
                          <option value="1">One</option>
                          <option value="2">Two</option>
                          <option value="3">Three</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-6 col-md-3">
                      <div class="form-group">
                        <label for="cardNumber">Year</label>
                        <select class="custom-select">
                          <option selected="">Open this select menu</option>
                          <option value="1">One</option>
                          <option value="2">Two</option>
                          <option value="3">Three</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-12">
                      <a href="#!" class="btn btn-primary">Add</a>
                    </div>
                  </div>
                </div> -->

                <!-- wishlist -->
                <!-- <div
                  class="tab-pane fade"
                  id="sidebar-1-5"
                  role="tabpanel"
                  aria-labelledby="sidebar-1-5"
                >
                  <div class="row">
                    <div class="col">
                      <h3 class="mb-0">Wishlist</h3>
                      <span class="eyebrow">3 Product</span>
                    </div>
                  </div>
                  <div class="row gutter-2">
                    <div class="col-md-6 col-lg-4">
                      <div class="product">
                        <div class="product-options">
                          <select id="inputState" class="custom-select">
                            <option selected="">Color</option>
                            <option>Black</option>
                            <option>Blue</option>
                          </select>
                          <select id="inputState2" class="custom-select">
                            <option selected="">Size</option>
                            <option>Large</option>
                            <option>Small</option>
                          </select>
                        </div>
                        <figure class="product-image">
                          <a href="#!" class="btn btn-ico btn-rounded btn-white"
                            ><i class="icon-x"></i
                          ></a>
                          <a href="#!">
                            <img
                              src="../../assets/images/product-1.jpg"
                              alt="Image"
                            />
                            <img
                              src="../../assets/images/product-1-2.jpg"
                              alt="Image"
                            />
                          </a>
                        </figure>
                        <div class="product-meta">
                          <h3 class="product-title">
                            <a href="#!">Fawn Wool / Natural Mammoth Chair </a>
                          </h3>
                          <div class="product-price">
                            <span>$2,268</span>
                            <span class="product-action">
                              <a href="#!">Add to cart</a>
                            </span>
                          </div>
                          <a href="#!" class="product-like"></a>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                      <div class="product">
                        <div class="product-options">
                          <select id="inputState3" class="custom-select">
                            <option selected="">Color</option>
                            <option>Black</option>
                            <option>Blue</option>
                          </select>
                          <select id="inputState4" class="custom-select">
                            <option selected="">Size</option>
                            <option>Large</option>
                            <option>Small</option>
                          </select>
                        </div>
                        <figure class="product-image">
                          <a href="#!" class="btn btn-ico btn-rounded btn-white"
                            ><i class="icon-x"></i
                          ></a>
                          <div
                            class="owl-carousel"
                            data-nav="true"
                            data-loop="true"
                          >
                            <a href="#!">
                              <img
                                src="../../assets/images/product-2.jpg"
                                alt="Image"
                              />
                            </a>
                            <a href="#!">
                              <img
                                src="../../assets/images/product-2-2.jpg"
                                alt="Image"
                              />
                            </a>
                            <a href="#!">
                              <img
                                src="../../assets/images/product-2-3.jpg"
                                alt="Image"
                              />
                            </a>
                          </div>
                        </figure>
                        <div class="product-meta">
                          <h3 class="product-title">
                            <a href="#!">Dark Stained NY11 Dining Chair</a>
                          </h3>
                          <div class="product-price">
                            <span>$504</span>
                            <span class="product-action">
                              <a href="#!">Add to cart</a>
                            </span>
                          </div>
                          <a href="#!" class="product-like"></a>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-6 col-lg-4">
                      <div class="product">
                        <div class="product-options">
                          <select id="inputState5" class="custom-select">
                            <option selected="">Color</option>
                            <option>Black</option>
                            <option>Blue</option>
                          </select>
                          <select id="inputState6" class="custom-select">
                            <option selected="">Size</option>
                            <option>Large</option>
                            <option>Small</option>
                          </select>
                        </div>
                        <figure class="product-image">
                          <a href="#!" class="btn btn-ico btn-rounded btn-white"
                            ><i class="icon-x"></i
                          ></a>
                          <a href="#!">
                            <img
                              src="../../assets/images/product-3.jpg"
                              alt="Image"
                            />
                            <img
                              src="../../assets/images/product-3-2.jpg"
                              alt="Image"
                            />
                          </a>
                        </figure>
                        <div class="product-meta">
                          <h3 class="product-title">
                            <a href="#!">Black IC Pendant Light</a>
                          </h3>
                          <div class="product-price">
                            <span>$410</span>
                            <span class="product-action">
                              <a href="#!">Add to cart</a>
                            </span>
                          </div>
                          <a href="#!" class="product-like"></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div> -->
              </div>
            </div>
          </div>
        </div>
        <!-- / content -->
      </div>
    </div>
  </section>
  <!-- listing -->
</template>
<script>
var baseAddress = "http://localhost:7250";
export default {
  data() {
    return {
      orders: [],
      orderDetails: [],
    };
  },
  methods: {
    async fetchOrders() {
      try {
        const memberId = 3;
        const response = await fetch(`${baseAddress}/api/Orders/${memberId}`);
        const data = await response.json();
        console.log(data);
        this.orders = data;

        //迭代orders
        for (const order of this.orders) {
          await this.fetchOrderDetail(order.orderId);
        }
      } catch (error) {
        console.error("error fetching orders", error);
      }
    },
    async fetchOrderDetail(orderId) {
      try {
        const response = await fetch(
          `${baseAddress}/api/OrderDetails/${orderId}`
        );
        const data = await response.json();
        console.log(data);
        this.orderDetails[orderId] = data;
      } catch (error) {
        console.error("error fetching order details", error);
      }
    },
  },
  mounted() {
    this.fetchOrders();
  },
};
</script>
<style></style>
