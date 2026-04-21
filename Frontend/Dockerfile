FROM node:20 as build
WORKDIR /app   

COPY package.json ./
RUN npm install 

# copy all missing code 
COPY . .
RUN npm run build

# small image to execute publish stage
FROM nginx:alpine as final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/build .

