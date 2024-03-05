import { createWebHistory, createRouter } from "vue-router";
import Cart from "./components/Cart.vue";
import Checkout from "./components/Checkout.vue";
import Profile_order from "./components/Profile_order.vue";
import Product_listing from "./components/Product_listing.vue";
import Custom_listing from "./components/Custom_listing.vue";

const routes = [
  { path: "/cart", component: Cart },
  { path: "/checkout", component: Checkout },
  { path: "/profile_order", component: Profile_order },
  { path: "/product_listing", component: Product_listing },
  { path: "/custom_listing", component: Custom_listing },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
