# Etapa 1: build da aplicação
FROM node:20-alpine as builder
WORKDIR /app
COPY . .
RUN npm install && npm run build

# Etapa 2: servidor Nginx
FROM nginx:alpine
COPY --from=builder /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
