<template>
  <!-- breadcrumbs -->
  <section class="breadcrumbs separator-bottom">
    <div class="container">
      <div class="row">
        <div class="col">
          <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
              <li class="breadcrumb-item"><a href="index.html">主頁</a></li>
              <li class="breadcrumb-item active" aria-current="page">
                所有主包
              </li>
            </ol>
          </nav>
        </div>
      </div>
    </div>
  </section>
  <!-- listing -->
  <section class="pt-6">
    <div class="container">
      <div class="row justify-content-end">
        <div class="col-lg-9">
          <div class="row gutter-2 align-items-end">
            <div class="col-md-6">
              <h1 class="mb-0">所有主包</h1>
              <span class="eyebrow">{{ products.length }} products</span>
            </div>
            <div class="col-md-6 text-md-right">
              <div class="dropdown">
                <a
                  class="btn btn-outline-secondary btn-sm dropdown-toggle"
                  href="#!"
                  role="button"
                  id="dropdownMenuLink"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  排序
                </a>

                <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                  <a class="dropdown-item" href="#!">預設排序</a>
                  <a class="dropdown-item" href="#!">價格由高至低</a>
                  <a class="dropdown-item" href="#!">價格由低至高</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="row gutter-4">
        <!-- sidebar -->
        <aside class="col-lg-3 sidebar">
          <!-- 品牌 -->
          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-brand"
              aria-expanded="false"
              aria-controls="collapse-brand"
              role="button"
            >
              按品牌篩選
            </span>
            <div class="d-lg-block collapse" id="collapse-brand">
              <span class="widget-title">品牌</span>
              <div class="widget-content">
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck1"
                  />
                  <label class="custom-control-label" for="customCheck1"
                    >NIKE</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck2"
                  />
                  <label class="custom-control-label" for="customCheck2"
                    >THE NORTH FACE</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck3"
                  />
                  <label class="custom-control-label" for="customCheck3"
                    >ARCTERYX 始祖鳥</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck4"
                  />
                  <label class="custom-control-label" for="customCheck4"
                    >PORTER INTERNATIONAL</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck5"
                  />
                  <label class="custom-control-label" for="customCheck5"
                    >Samsonite 新秀麗
                  </label>
                </div>
              </div>
            </div>
          </div>
          <!-- 功能 -->
          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-function"
              aria-expanded="false"
              aria-controls="collapse-function"
              role="button"
            >
              按功能篩選
            </span>
            <div class="d-lg-block collapse" id="collapse-function">
              <span class="widget-title">功能</span>
              <div class="widget-content">
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckFunction1"
                  />
                  <label class="custom-control-label" for="customCheckFunction1"
                    >多功能</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckFunction2"
                  />
                  <label class="custom-control-label" for="customCheckFunction2"
                    >旅行</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckFunction3"
                  />
                  <label class="custom-control-label" for="customCheckFunction3"
                    >休閒</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckFunction4"
                  />
                  <label class="custom-control-label" for="customCheckFunction4"
                    >登山</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckFunction5"
                  />
                  <label class="custom-control-label" for="customCheckFunction5"
                    >商務</label
                  >
                </div>
              </div>
            </div>
          </div>

          <!-- 類別 -->
          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-category"
              aria-expanded="false"
              aria-controls="collapse-category"
              role="button"
            >
              按類別篩選
            </span>
            <div class="d-lg-block collapse" id="collapse-category">
              <span class="widget-title">類別</span>
              <div class="widget-content">
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckCategory1"
                  />
                  <label class="custom-control-label" for="customCheckCategory1"
                    >後背包</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckCategory2"
                  />
                  <label class="custom-control-label" for="customCheckCategory2"
                    >旅行包</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckCategory3"
                  />
                  <label class="custom-control-label" for="customCheckCategory3"
                    >公事包</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheckCategory4"
                  />
                  <label class="custom-control-label" for="customCheckCategory4"
                    >斜肩包</label
                  >
                </div>
              </div>
            </div>
          </div>

          <!-- 價格 -->
          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-price"
              aria-expanded="false"
              aria-controls="collapse-price"
              role="button"
            >
              按價格篩選
            </span>
            <div class="d-lg-block collapse" id="collapse-price">
              <span class="widget-title">價格</span>
              <div class="widget-content">
                <input
                  type="text"
                  class="rangeslider"
                  name="Range Slider"
                  value=""
                />
              </div>
            </div>
          </div>
        </aside>

        <!-- content -->
        <div class="col-lg-9">
          <div class="row gutter-2 gutter-lg-3">
            <div
              class="col-6 col-md-4"
              v-for="product in paginatedProducts"
              :key="product.ProductId"
            >
              <div class="product">
                <figure class="product-image">
                  <a href="#!">
                    <img
                      :src="`../../assets/images/productImg/${product.ImageFileName}`"
                      alt="Image"
                    />
                  </a>
                </figure>
                <div class="product-meta">
                  <h3 class="product-title">
                    <a href="#!">{{ product.Name }} </a>
                  </h3>
                  <div class="product-price">
                    <span>{{ product.SalePrice }}元</span>
                    <span class="product-action">
                      <a href="#!">加入購物車</a>
                    </span>
                  </div>
                  <a href="#!" class="product-like"></a>
                </div>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col">
              <nav class="d-inline-block">
                <!-- pagination -->
                <Pagination
                  :currentPage="currentPage"
                  :totalPages="totalPages"
                  @setCurrentPage="setCurrentPage"
                />
              </nav>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
var baseAddress = "http://localhost:7250";
import Pagination from "./Pagination.vue";
export default {
  components: {
    Pagination,
  },
  data() {
    return {
      products: [],
      productsPerPage: 9,
      currentPage: 1,
    };
  },
  methods: {
    async fetchProducts() {
      try {
        const response = await fetch(`${baseAddress}/api/Products`, {
          method: "GET",
        });

        if (response.ok) {
          const data = await response.json();
          //this.products = data.filter((product) => product.Category === "主包");
          this.products = data;
          console.log(data);
        } else {
          console.log("Failed to fetch products");
        }
      } catch (err) {
        console.log(err);
      }
    },
    setCurrentPage(page) {
      this.currentPage = page;
    },
  },
  mounted() {
    this.fetchProducts();
  },
  computed: {
    totalPages() {
      return Math.ceil(this.products.length / this.productsPerPage);
    },
    paginatedProducts() {
      const startIndex = (this.currentPage - 1) * this.productsPerPage;
      const endIndex = startIndex + this.productsPerPage;
      return this.products.slice(startIndex, endIndex);
    },
  },
};
</script>
<style></style>
