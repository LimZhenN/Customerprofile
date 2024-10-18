import React from 'react';

function CustomerList({ customers, onSelectCustomer, onDeleteCustomer }) {
  return (
    <div className="customer-list">
      <h2>Customers</h2>
      <ul>
        {customers.map(customer => (
          <li key={customer.id}>
            {customer.firstName} {customer.lastName}
            <button onClick={() => onSelectCustomer(customer)}>Edit</button>
            <button onClick={() => onDeleteCustomer(customer.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default CustomerList;