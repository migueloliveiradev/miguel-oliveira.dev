const { createApp } = Vue

const app = createApp({
    data() {
        return {
            technologies: [],
            technologiesSelected: [],
            selected: Number
        }
    },
    methods: {
        AddTech() {
            console.log(this.selected);
            if (this.selected == null || this.selected == undefined || this.selected == '')
                return
            console.log(this.selected);

            this.technologies = this.technologies.filter(tech => tech.id != this.selected)
            console.log(this.technologiesSelected);
            this.technologiesSelected.push(this.technologies.find(p => p.id != this.selected))
            console.log(this.technologiesSelected);
            this.selected = this.technologies[0] ?? '';
        },
        salvar() {
            console.log("salvando...");
            this.clear()
        },
        clear() {
            this.technologiesSelected = [];
            this.technologies = [];
            this.selected = '';
        }
    },
    mounted() {
        const modal = document.getElementById('modalEditTechnologies');
        modal.addEventListener('show.bs.modal', async event => {
            const button = event.relatedTarget
            const id = button.getAttribute('data-bs-project-id')
            console.log(id);
            let response = await axios.get(`/dashboard/projects/${id}/tecnologies/get`)
            this.technologies = response.data.technology_not_selected;
            this.technologiesSelected = response.data.technology;
            this.selected = this.technologies[0].id ?? '';
            console.log(this.technologies);
            console.log(this.technologiesSelected);
        });
    }
})
app.mount('#modalEditTechnologies')