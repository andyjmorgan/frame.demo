#stage 1
FROM node:latest as node
WORKDIR /src
COPY . .

WORKDIR "/src/frame.demo.stack.client"
RUN npm install
RUN npm run build --prod

#stage 2
FROM nginx:alpine
COPY ./frame.demo.stack.client/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=node /src/frame.demo.stack.client/dist/frame.demo.stack.client/browser /usr/share/nginx/html

# Expose port 81
EXPOSE 8081
