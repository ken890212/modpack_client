<template>
  <!-- pagination -->
  <div class="row">
    <div class="col">
      <ul class="pagination">
        <li
          v-for="page in totalPages"
          :key="page"
          class="page-item"
          :class="{ active: page === currentPage }"
        >
          <a class="page-link" href="#" @click.prevent="setCurrentPage(page)">{{
            page
          }}</a>
        </li>
      </ul>
    </div>
  </div>
</template>
<script>
export default {
  props: { currentPage: Number, totalPages: Number },
  methods: {
    setCurrentPage(page) {
      this.$emit("setCurrentPage", page);
    },
  },
};
</script>
<style></style>
