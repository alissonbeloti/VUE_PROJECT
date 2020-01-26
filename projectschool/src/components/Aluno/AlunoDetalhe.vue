<template>
  <div>
    <titulo :texto="'Aluno: ' + aluno.nome" :btnVoltar="this.editar">
      <button class="btn btnEditar" @click="edicao()">{{this.botao}}</button>
    </titulo>
    <table>
      <tbory>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="!this.editar">{{aluno.nome}}</label>
            <input v-else type="text" v-model="aluno.nome" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="!this.editar">{{aluno.sobrenome}}</label>
            <input v-if="this.editar" type="text" v-model="aluno.sobrenome" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data de nasc.:</td>
          <td>
            <label v-if="!this.editar">{{aluno.dataNasc}}</label>
            <input v-if="this.editar" type="text" v-model="aluno.dataNasc" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="!this.editar">{{aluno.professor.nome}}</label>
            <select v-if="this.editar" v-model="aluno.professor">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor"
              >{{professor.nome}}</option>
            </select>
          </td>
        </tr>
      </tbory>
    </table>
    <div style="margin-top: 10px">
      <div v-if="this.editar">
        <button class="btn btnSalvar" @click="salvar()">Salvar</button>
        <button class="btn btnCancelar" @click="edicao()">Cancelar</button>
      </div>
    </div>
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
      editar: false,
      botao: "Editar",
      aluno: {},
      professores: [],
      idAluno: this.$route.params.id
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos/" + this.idAluno)
      .then(res => res.json())
      .then(aluno => (this.aluno = aluno));
    this.$http
      .get("http://localhost:3000/professores")
      .then(res => res.json())
      .then(professores => (this.professores = professores));
  },
  methods: {
    edicao() {
      this.editar = !this.editar;
      if (this.botao == "Editar") this.botao = "Cancelar";
      else this.botao = "Editar";
    },
    salvar() {
      let _alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.dataNasc,
        professor: this.aluno.professor
      };
      this.$http.put(
        `http://localhost:3000/alunos/${_alunoEditar.id}`,
        _alunoEditar
      );
      this.edicao();
    }
  }
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
}
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}
.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}
.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}
input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  width: 95%;
  background-color: rgb(245, 245, 245);
}
select {
  height: 38px;
  widows: 100%;
}
</style>