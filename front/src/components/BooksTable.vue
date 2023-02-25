<script setup>
const props = defineProps({
    fields: Array,
    books: Array
})

const emitDeleteBook = defineEmits(['deleteBook'])
const deleteBook = (book) => {
    emitDeleteBook('deleteBook', book)
}
</script>

<template>
    <table class="table">
        <thead>
            <tr>
                <th v-for="field in props.fields" :key="field.key">
                    {{ field.label }}
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="book in props.books" :key="book.Id">
                <td v-for="field in fields">
                    {{ book[field.key] }}
                </td>
                <td>
                    <button>Editar</button>
                    <button @click="deleteBook(book)">Excluir</button>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<style scoped></style>