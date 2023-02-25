import { defineStore } from "pinia"

export const useBooksStore = defineStore('books', {
    state: () => ({
        fields: [
            { key: "Id", label: "Id" },
            { key: "Name", label: "Título" },
            { key: "Author", label: "Autor" },
            { key: "Category", label: "Categoria" },
            { key: "Price", label: "Preço" }
        ],
        books: [
            {
                Name: "Clean Architecture",
                Price: 15,
                Category: "Computer Science",
                Author: "Uncle Bob",
                Id: "63f2587d545ddd66efd42e28"
            },
            {
                Name: "God's city",
                Price: 1,
                Category: "True Crime",
                Author: "Little Zé",
                Id: "63f25fff12521e1c8f892456"
            },
            {
                Name: "The Witcher - Game manual",
                Price: 5,
                Category: "Fantasy",
                Author: "CD Project Red",
                Id: "63f26f180c6eed47a25b9b95"
            }
        ]
    }),

    getters: {
        readBooks: (state) => state.books,
        readFields: (state) => state.fields
    },

    actions: {
        create(b) {
            this.books.push(b)
        },
        update(oldAndNewBook) {
            const index = this.books.indexOf(oldAndNewBook.old)
            this.books.splice(index, 1, [oldAndNewBook.new])
        },
        delete(bookId) {
            this.books = this.books.filter((b) => b.Id != bookId)
        }
    }
})