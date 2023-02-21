<template>
  <table class="table table-hover">
    <thead>
      <tr>
        <th v-for="field in fields" :key="field.key">
          {{ field.label }}
        </th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="book in books" :key="book.Id">
        <td v-for="field in fields">
          {{ book[field.key] }}
        </td>
        <td>
          <button class="btn btn-outline-primary table-button">Editar</button>
          <button @click="deleteBook(book)" class="btn btn-outline-danger" table-button>Excluir</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>
  
<script setup>
  import { ref } from 'vue'

  const fields = [
    { key: "Id", label: "Id"},
    { key: "Name", label: "Título" },
    { key: "Author", label: "Autor" },
    { key: "Category", label: "Categoria" },
    { key: "Price", label: "Preço" }
  ]
  let books = ref([
    {
      Name: "Clean Architecture",
      Price: 15,
      Category: "Computer Science",
      Author: "Uncle Bob",
      Id: "63f2587d545ddd66efd42e28"
    },
    {
      Name: "CDD",
      Price: 1,
      Category: "True Crime",
      Author: "Little Zé",
      Id: "63f25fff12521e1c8f892456"
    },
    {
      Name: "The Witcher",
      Price: 19,
      Category: "Fantasy",
      Author: "An awesome Polonian",
      Id: "63f26ee50c6eed47a25b9b94"
    },
    {
      Name: "The Witcher - Game manual",
      Price: 5,
      Category: "Fantasy",
      Author: "CD Project Red",
      Id: "63f26f180c6eed47a25b9b95"
    },
    {
      Name: "Boomshakalaka",
      Price: 96,
      Category: "BBall",
      Author: "Bulls",
      Id: "63f28ebaa96935803e95fd41"
    }
  ])

  const deleteBook = (book) => {
    books.value = books.value.filter((x) => x.Id != book.Id)
  }
</script>
  
<style scoped>
  .table-button {
    margin: 0 0.5rem 0 0.5rem;
  }
</style>
