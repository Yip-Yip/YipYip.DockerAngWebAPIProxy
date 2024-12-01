# Stage 1: Build the Angular application
FROM node:18.13 AS builder

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install the application dependencies
RUN npm install

# Copy the rest of the application code to the working directory
COPY . .

# Build the Angular app
RUN npm run build -- --output-path=./dist/out --configuration=production

# Stage 2: Serve the application with NGINX
FROM nginx:1.23-alpine

# Copy the built Angular app from the builder stage to the NGINX html directory
COPY --from=builder /app/dist/out/browser/ /usr/share/nginx/html/web

# Expose port 80
EXPOSE 80

# Start NGINX server
CMD ["nginx", "-g", "daemon off;"]
