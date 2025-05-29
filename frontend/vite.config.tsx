import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
    root: './public/',
    plugins: [react()],
    server: {
        port: 5173,
        open: true,
        proxy: {
            '/api': 'http://localhost:5075' // Прокси для API
        }
    },
    build: {
        outDir: 'dist',
        emptyOutDir: true
    }
});