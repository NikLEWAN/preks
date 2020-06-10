interface ITransportTab {
    id: number
    lastbil: string
    chauffor: string
    dato: string
    antalKm: number
    gennemsnit: number
}

let baseUri: string = "https://localhost:44367/api/transporttabs"

new Vue({
    el: "#app",
    data: {
        transporttabs: [],
        errors: [],
        deleteId: 0,
        deleteMessage: "",
        formData: { lastbil: "", chauffor: "", dato: "", antalKm: 0, gennemsnit: 0 },
        addMessage: ""
    },
    methods: {
        getAllCars() {
            axios.get<ITransportTab[]>(baseUri)
                .then((response: AxiosResponse<ITransportTab[]>) => {
                    this.transporttabs = response.data
                })
                .catch((error: AxiosError) => {
                    //this.message = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        deleteCar(deleteId: number) {
            let uri: string = baseUri + "/" + deleteId
            axios.delete<void>(uri)
                .then((response: AxiosResponse<void>) => {
                    this.deleteMessage = response.status + " " + response.statusText
                    this.getAllCars()
                })
                .catch((error: AxiosError) => {
                    //this.deleteMessage = error.message
                    alert(error.message)
                })
        },
        addCar() {
            axios.post<ITransportTab>(baseUri, this.formData)
                .then((response: AxiosResponse) => {
                    let message: string = "response " + response.status + " " + response.statusText
                    this.addMessage = message
                    this.getAllCars()
                })
                .catch((error: AxiosError) => {
                    // this.addMessage = error.message
                    alert(error.message)
                })
        }
    }
})