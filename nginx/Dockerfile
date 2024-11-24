FROM nginx

# Copy configuration and index.html
COPY nginx/nginx.conf /etc/nginx/nginx.conf

# Copy built Angular app
COPY nginx/index.html /usr/share/nginx/html/index.html

EXPOSE 80


# Start NGINX
CMD ["nginx", "-g", "daemon off;"]