# Use an official Node.js runtime as a parent image
FROM node:14-alpine as builder

# Set the working directory to /app
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the app's source code to the container
COPY . .

# Build the app
RUN npm run build --prod

# Use a smaller image for the runtime
FROM nginx:1.21-alpine

# Copy the built app from the builder stage to the runtime image
COPY --from=builder /app/dist/client-app /usr/share/nginx/html

# Expose port 80 to the host
EXPOSE 80

# Start nginx in the foreground when the container starts
CMD ["nginx", "-g", "daemon off;"]
