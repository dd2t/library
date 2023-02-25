<script setup>
import { ref } from 'vue'
import { useBooksStore } from '../store/BooksStore'

const props = defineProps({
  book: Object
})

const store = useBooksStore()

const book = ref({
  Id: null,
  Name: props.book?.Name || 'Water I',
  Price: props.book?.Price || 10,
  Category: props.book?.Category || 'Fantasy',
  Author: props.book?.Author || 'MDS Moura'
})

const saveBook = () => {
  if (book.Id != null) store.update({old: props.book, new: book.value})
  store.create(book.value)
}
</script>

<template>
  <div class="form">
    <div class="column">
      <span class="label">Nome: </span>
      <span class="label">Autor: </span>
      <span class="label">Categoria: </span>
      <span class="label">Preço: </span>
    </div>
    <div class="column">
      <input v-model="book.Name" type="text"> 
      <input v-model="book.Author" type="text">
      <input v-model="book.Category" type="text">
      <input v-model="book.Price" type="number">
    </div>
    <div class="column">
      <p>{{ book.Name }}</p>
      <p>{{ book.Author }}</p>
      <p>{{ book.Category }}</p>
      <p>R$ {{ book.Price }}</p>
    </div>
    <div class="column">
      <button @click="saveBook" class="btn">Salvar</button>
    </div>
  </div>
</template>

<style scoped>
@media (min-width: 1024px) {
  .form {
    display: flex;
    align-items: center;
  }
  .column {
    padding-left: 2rem;
    display: flex;
    align-items: center;
    justify-content: space-between;
    flex-direction: column;
  }
  .btn {
    margin-top: 1rem;
  }
}
</style>
