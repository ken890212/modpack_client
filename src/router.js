import { createWebHistory, createRouter } from "vue-router";
import Cart from "./components/Cart.vue";
import Checkout from "./components/Checkout.vue";
import Profile_order from "./components/Profile_order.vue";

const routes = [
  {
    path: "/cart",
    component: Cart,
  },
  {
    path: "/checkout",
    component: Checkout,
  },
  { path: "/profile_order", component: Profile_order },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
