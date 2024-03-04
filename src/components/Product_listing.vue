<template>
  <!-- breadcrumbs -->
  <section class="breadcrumbs separator-bottom">
    <div class="container">
      <div class="row">
        <div class="col">
          <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
              <li class="breadcrumb-item"><a href="index.html">Home</a></li>
              <li class="breadcrumb-item active" aria-current="page">
                Listing
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
              <span class="eyebrow">20 products</span>
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
                  What's New
                </a>

                <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                  <a class="dropdown-item" href="#!">What's New</a>
                  <a class="dropdown-item" href="#!">Price high to low</a>
                  <a class="dropdown-item" href="#!">Price low to high</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="row gutter-4">
        <!-- sidebar -->
        <aside class="col-lg-3 sidebar">
          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-1"
              aria-expanded="false"
              aria-controls="collapse-1"
              role="button"
            >
              Filter by Category
            </span>
            <div class="d-lg-block collapse" id="collapse-1">
              <span class="widget-title">Categories</span>
              <div class="widget-content">
                <ul id="page-nav" class="nav flex-column nav-category">
                  <li class="nav-item">
                    <a
                      class="nav-link"
                      data-toggle="collapse"
                      href="#menu-2"
                      role="button"
                      aria-expanded="false"
                      aria-controls="menu-2"
                      >Women</a
                    >
                    <div class="collapse" id="menu-2" data-parent="#page-nav">
                      <div>
                        <ul class="nav flex-column">
                          <li class="nav-item">
                            <a class="nav-link" href="#!">New In</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Clothing</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Shoes</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Accessories</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Face + Body</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Outlet</a>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </li>
                  <li class="nav-item">
                    <a
                      class="nav-link"
                      data-toggle="collapse"
                      href="#menu-3"
                      role="button"
                      aria-expanded="false"
                      aria-controls="menu-3"
                      >Men</a
                    >
                    <div class="collapse" id="menu-3" data-parent="#page-nav">
                      <div>
                        <ul class="nav flex-column">
                          <li class="nav-item">
                            <a class="nav-link" href="#!">New In</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Clothing</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Shoes</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Accessories</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Face + Body</a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link" href="#!">Outlet</a>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </div>

          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-2"
              aria-expanded="false"
              aria-controls="collapse-2"
              role="button"
            >
              Filter by Brand
            </span>
            <div class="d-lg-block collapse" id="collapse-2">
              <span class="widget-title">Brands</span>
              <div class="widget-content">
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck1"
                  />
                  <label class="custom-control-label" for="customCheck1"
                    >Calvin Klein</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck2"
                  />
                  <label class="custom-control-label" for="customCheck2"
                    >Ralph Lauren</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck3"
                  />
                  <label class="custom-control-label" for="customCheck3"
                    >Michael Kors</label
                  >
                </div>
                <div class="custom-control custom-checkbox">
                  <input
                    type="checkbox"
                    class="custom-control-input"
                    id="customCheck4"
                  />
                  <label class="custom-control-label" for="customCheck4"
                    >Balenciaga</label
                  >
                </div>
              </div>
            </div>
          </div>

          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-3"
              aria-expanded="false"
              aria-controls="collapse-3"
              role="button"
            >
              Filter by Size
            </span>
            <div class="d-lg-block collapse" id="collapse-3">
              <span class="widget-title">Size</span>
              <div class="widget-content">
                <div
                  class="btn-group-toggle btn-group-square"
                  data-toggle="buttons"
                >
                  <label class="btn active">
                    <input
                      type="checkbox"
                      name="options"
                      id="option1"
                      checked=""
                    />
                    S
                  </label>
                  <label class="btn">
                    <input type="checkbox" name="options" id="option2" /> M
                  </label>
                  <label class="btn">
                    <input type="checkbox" name="options" id="option3" /> L
                  </label>
                  <label class="btn">
                    <input type="checkbox" name="options" id="option4" /> XL
                  </label>
                  <label class="btn">
                    <input type="checkbox" name="options" id="option2" /> XXL
                  </label>
                  <label class="btn">
                    <input type="checkbox" name="options" id="option3" /> 3XL
                  </label>
                </div>
              </div>
            </div>
          </div>

          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-4"
              aria-expanded="false"
              aria-controls="collapse-4"
              role="button"
            >
              Filter by Color
            </span>
            <div class="d-lg-block collapse" id="collapse-4">
              <span class="widget-title">Color</span>
              <div class="widget-content">
                <div
                  class="btn-group-toggle btn-group-square btn-group-colors"
                  data-toggle="buttons"
                >
                  <label class="btn active text-red">
                    <input
                      type="checkbox"
                      name="options"
                      id="option1-2"
                      checked=""
                    />
                  </label>
                  <label class="btn text-blue">
                    <input type="checkbox" name="options" id="option2-2" />
                  </label>
                  <label class="btn text-yellow">
                    <input type="checkbox" name="options" id="option3-2" />
                  </label>
                  <label class="btn text-green">
                    <input type="checkbox" name="options" id="option4-2" />
                  </label>
                </div>
              </div>
            </div>
          </div>

          <div class="widget">
            <span
              class="widget-collapse d-lg-none"
              data-toggle="collapse"
              data-target="#collapse-5"
              aria-expanded="false"
              aria-controls="collapse-5"
              role="button"
            >
              Filter by Price
            </span>
            <div class="d-lg-block collapse" id="collapse-5">
              <span class="widget-title">Price</span>
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
            <div class="col-6 col-md-4">
              <div class="product">
                <figure class="product-image">
                  <a href="#!">
                    <img src="../../assets/images/product-1.jpg" alt="Image" />
                    <img
                      src="../../assets/images/product-1-2.jpg"
                      alt="Image"
                    />
                  </a>
                </figure>
                <div class="product-meta">
                  <h3 class="product-title">
                    <a href="#!">product.name </a>
                  </h3>
                  <div class="product-price">
                    <span>product.price</span>
                    <span class="product-action">
                      <a href="#!">Add to cart</a>
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
export default {};
</script>
<style></style>
