<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <!-- <td>{{index+1}}</td> -->
          <td>{{professor.id}}</td>
          <td>{{professor.nome}} {{professor.sobrenome}}</td>
          <td></td>
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
      Professores: [
        { id: 1, nome: "Alisson", sobrenome: "Silva" },
        { id: 1, nome: "Paola", sobrenome: "Souza" },
        { id: 1, nome: "Breno", sobrenome: "Castel" }
      ]
    };
  }
};
</script>

<style scoped>
</style>