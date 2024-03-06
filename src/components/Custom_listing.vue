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
                客製化商品
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
              <h1 class="mb-0">客製化商品</h1>
              <span class="eyebrow"> products</span>
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
                  v-model="priceRange"
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
              v-for="inspiration in inspirations"
              :key="inspiration.InspirationId"
            >
              <div class="product">
                <figure class="product-image">
                  <a href="#!">
                    <img
                      :src="`http://localhost:7251/images/Inspiration/${inspiration.ImageFileName}`"
                      alt="Image"
                    />
                  </a>
                </figure>
                <div class="product-meta">
                  <h3 class="product-title">
                    <a href="#!">{{ inspiration.Name }} </a>
                  </h3>
                  <div class="product-price">
                    <span>{{ inspiration.SalePrice }}元</span>
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
export default {
  data() {
    return {
      inspirations: [],
    };
  },
  methods: {
    async fetchInspirations() {
      try {
        const response = await fetch(`${baseAddress}/api/Inspirations`, {
          method: "GET",
        });

        if (response.ok) {
          const data = await response.json();
          this.inspirations = data;

          console.log(data);
        } else {
          console.log("Failed to fetch inspirations");
        }
      } catch (err) {
        console.log(err);
      }
    },
  },
  mounted() {
    this.fetchInspirations();
  },
};
</script>
<style></style>
