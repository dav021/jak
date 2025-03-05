import axios from 'axios';
import { Product } from '../app/models/product';

const API_URL = 'http://localhost:5004/api/Products';

const apiClient = axios.create({
    baseURL: API_URL,
    timeout: 1000,
});

export const getProducts = async () => {
    const response = await apiClient.get('/');
    return response.data;
};

export const addProduct = async (product: Omit<Product, 'id'>) => {
    const response = await apiClient.post(API_URL, product);
    return response.data;
};

export const deleteProduct = async (id: string) => {
    const response = await apiClient.delete(`${API_URL}/${id}`);
    return response.data;
};





