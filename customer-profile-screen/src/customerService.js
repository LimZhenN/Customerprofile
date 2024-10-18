import axios from 'axios';

const API_BASE_URL = 'http://localhost:5225/api/CusInfo'; // Adjust this to match your backend URL

const api = axios.create({
  baseURL: API_BASE_URL,
});

export const getCustomers = () => api.get('');
export const getCustomer = (id) => api.get(`/${id}`);
export const createCustomer = (customer) => api.post('', customer);
export const updateCustomer = (id, customer) => api.put(`/${id}`, customer);
export const deleteCustomer = (id) => api.delete(`/${id}`);

// Add error handling
api.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Error:', error);
    return Promise.reject(error);
  }
);
