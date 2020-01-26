<template>
  <div>
    <titulo texto="Professores" :btnVoltar="true" />
    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <!-- <td>{{index+1}}</td> -->
          <td class="colPequeno">{{professor.id}}</td>

          <router-link
            :to="`/alunos/${professor.id}`"
            tag="td"
            style="cursor: pointer"
          >{{professor.nome}} {{professor.sobrenome}}</router-link>

          <td class="colPequeno">{{professor.qtdAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum Professor Encontrado!</tfoot>
    </table>
  </div>
</template>

<script>
/* eslint-disable vue/no-unused-components */
import Titulo from "../_share/Titulo";
export default {
  components: { Titulo },
  data() {
    return {
      Professores: [],
      Alunos: []
    };
  },
  created() {
    return this.$http
      .get("http://localhost:3000/alunos")
      .then(res => res.json())
      .then(alunos => {
        this.Alunos = alunos;
        this.carregarProfessores();
      });
  },
  props: {},
  methods: {
    qtdAlunosPorProfessor() {
      this.Professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          sobrenome: professor.sobrenome,
          qtdAlunos: this.Alunos.filter(
            aluno => aluno.professor.id == professor.id
          ).length
        };
        this.Professores[index] = professor;
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:3000/professores")
        .then(res => res.json())
        .then(professores => {
          this.Professores = professores;
          this.qtdAlunosPorProfessor();
        });
    }
  }
};
</script>

<style scoped>
.colPequeno {
  text-align: center;
  width: 15%;
}
</style>