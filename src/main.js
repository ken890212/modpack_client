import { createApp } from "vue";
import mitt from "mitt";
import App from "./App.vue";
import router from "./router";

const eventbus = mitt();
const app = createApp(App);
app.config.globalProperties.eventbus = eventbus;
app.use(router);
app.mount("#app");
