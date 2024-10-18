import React, { useState, useEffect } from 'react';
import CustomerList from './CustomerList';
import CustomerForm from './CustomerForm';
import { getCustomers, createCustomer, updateCustomer, deleteCustomer } from './customerService';
import './App.css';

function App() {
  const [customers, setCustomers] = useState([]);
  const [selectedCustomer, setSelectedCustomer] = useState(null);

  useEffect(() => {
    fetchCustomers();
  }, []);

  const fetchCustomers = async () => {
    try {
      const response = await getCustomers();
      console.log('API response:', response);
      setCustomers(response.data);
    } catch (error) {
      console.error('Error fetching customers:', error);
    }
  };

  const handleCustomerSelect = (customer) => {
    setSelectedCustomer(customer);
  };

  const handleCustomerSubmit = async (customer) => {
    try {
      if (customer.id) {
        await updateCustomer(customer.id, customer);
      } else {
        await createCustomer(customer);
      }
      fetchCustomers();
      setSelectedCustomer(null);
    } catch (error) {
      console.error('Error submitting customer:', error);
    }
  };

  const handleCustomerDelete = async (id) => {
    try {
      await deleteCustomer(id);
      fetchCustomers();
      if (selectedCustomer && selectedCustomer.id === id) {
        setSelectedCustomer(null);
      }
    } catch (error) {
      console.error('Error deleting customer:', error);
    }
  };

  return (
    <div className="App">
      <h1>Customer Profile Management</h1>
      <div className="container">
        <CustomerList 
          customers={customers} 
          onSelectCustomer={handleCustomerSelect}
          onDeleteCustomer={handleCustomerDelete}
        />
        <CustomerForm 
          customer={selectedCustomer} 
          onSubmit={handleCustomerSubmit}
        />
      </div>
    </div>
  );
}

export default App;