FROM nginx

# Copy configuration and index.html
COPY nginx.conf /etc/nginx/nginx.conf
COPY index.html /usr/share/nginx/html/index.html

# Verify files are copied correctly
RUN ls -l /etc/nginx/nginx.conf && \
    ls -l /usr/share/nginx/html/index.html && \
    cat /usr/share/nginx/html/index.html

# Set correct permissions
RUN chmod 644 /usr/share/nginx/html/index.html

# Start NGINX
CMD ["nginx", "-g", "daemon off;"]