# DesafioBackEnd
Repositório do desafio Back-End.

# Instalação

Para baixar o projeto em sua maquina local, rode o seguinte comando no seu cmd:

```viml
git clone https://github.com/WesleyKCarlesso/DesafioBackEnd.git
```

Baixe o MongoDB em seu computador pelo link: https://www.mongodb.com/try/download/compass

Após feito isto, baixe o docker na sua máquina em: https://www.docker.com/products/docker-desktop/, logo após, abra o programa.

Agora com o cmd, entre na pasta do projeto aonde tem o arquivo "Dockerfile" e rode o comando:

```viml
docker-compose up -d
```

Veja se a instancia do docker está rodando com o comando 

```viml
docker ps
```

Agora, para executar a aplicação, digite os seguintes comandos no terminal em ordem:
```viml
dotnet dev-certs https --clean
dotnet dev-certs https --trust
dotner run
```

A seguir estará mostrando em qual porta a aplicação está rodando, copie e cole no seu navegador no seguinte formato:
```viml
https://localhost:[porta]/swagger/index.html
```

Tendo feito isto, no seu navegador estará aparecendo o sistema swagger com as APIs disponíveis.

# Usabilidade
Aqui temos as apis disponíveis no sistema:

### Post    /api/User
Adicionar um novo usuário com seus campos e seu endereço.
### Get     /api/User/all
Listagem dos usuários.
### Get     /api/User/{id}
Busca o usuário pelo Id.
### Put     /api/User/{id}
Atualiza o usuário conforme os campos informados.
### Delete  /api/User/{id}
Deleta o usuário pelo Id.
### Get     /api/User/filters
Busca todos os usuários que tenham o nome ou endereço informado.
