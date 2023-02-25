<script setup>
import { ref } from 'vue'
import BooksTable from '../components/BooksTable.vue'

const fields = [
    { key: "Id", label: "Id" },
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
  books.value = books.value.filter((b) => b.Id != book.Id)
}
</script>

<template>
  <main>
      <BooksTable :books="books" :fields="fields" @deleteBook="(book) => deleteBook(book)"/>
  </main>
</template>
