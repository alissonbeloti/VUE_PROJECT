<template>
  <div>
    <titulo
      :texto="this.professorid != undefined? `Professor: ${professor.nome}`: 'Todos Alunos'"
      :btnVoltar="true"
    />
    <div v-if="this.professorid != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="addAluno()" />
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
    </div>
    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <!-- <td>{{index+1}}</td> -->
          <td class="colPequeno">{{aluno.id}}</td>
          <router-link
            :to="`/alunoDetalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer"
          >{{aluno.nome}} {{aluno.sobrenome}}</router-link>
          <td class="colPequeno">
            <button class="btn btn_Danger" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Aluno Encontrado!</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo
  },
  data() {
    return {
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: []
    };
  },
  created() {
    if (this.professorid) {
      this.carregarProfessor();
      return this.$http
        .get(`http://localhost:5000/aluno/ByProfessor/${this.professorid}`)
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    } else {
      return this.$http
        .get("http://localhost:5000/aluno/")
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        dataNasc: "",
        professorid: this.professor.id
      };
      this.$http
        .post("http://localhost:5000/aluno", _aluno)
        .then(res => res.json())
        .then(aluno => this.alunos.push(aluno));
      this.nome = "";
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:5000/aluno/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    carregarProfessor() {
      this.$http
        .get(`http://localhost:5000/professor/${this.professorid}`)
        .then(res => res.json())
        .then(professor => {
          this.professor = professor;
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input {
  width: calc(100% -195px);
  border: 0;
  padding: 15px;
  font-size: 1.3em;
  color: #687f7f;
}
.btnInput {
  width: 140px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
}
.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
