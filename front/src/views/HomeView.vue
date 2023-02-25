<script setup>
import { computed } from 'vue'
import BooksTable from '../components/BooksTable.vue'
import { useBooksStore } from '../store/BooksStore'

const store = useBooksStore()

const fields = computed(() => store.readFields)
let books = computed(() => store.readBooks)
</script>

<template>
  <main>
      <BooksTable :books="books" :fields="fields" @deleteBook="(book) => store.delete(book.Id)"/>
  </main>
</template>
