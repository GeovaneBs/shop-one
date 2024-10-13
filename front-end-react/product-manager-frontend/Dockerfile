# Etapa 1: Build da aplicação
FROM node:22 AS build

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia os arquivos package.json e package-lock.json (se existir)
COPY package*.json ./

# Instala as dependências do projeto
RUN npm install

# Copia todos os arquivos do projeto para o diretório de trabalho do container
COPY . .

# Executa o build da aplicação
RUN npm run build

# Etapa 2: Configuração do servidor de produção
FROM nginx:alpine

# Copia os arquivos de build do React para o diretório padrão do Nginx
COPY --from=build /app/build /usr/share/nginx/html

# Expõe a porta 80
EXPOSE 80

# Comando para iniciar o Nginx
CMD ["nginx", "-g", "daemon off;"]
