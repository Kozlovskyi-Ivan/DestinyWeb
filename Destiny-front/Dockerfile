### Build ###
FROM node:12.7-alpine AS build
WORKDIR /usr/src/app/
 #ENV PATH app/node_modules
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build
### Run ###
#EXPOSE $PORT
FROM nginx:1.17.1-alpine
COPY --from=build /usr/src/app/dist/Destiny-front /usr/share/nginx/html
#
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

CMD sed -i -e 's/$PORT/'"$PORT"'/g' /etc/nginx/conf.d/default.conf && nginx -g 'daemon off;'
