import React, { useEffect } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

const CustomerForm = ({ customer, onSubmit }) => {
  const initialValues = {
    id: customer?.id || null,
    firstName: customer?.firstName || '',
    lastName: customer?.lastName || '',
    email: customer?.email || '',
    phoneNumber: customer?.phoneNumber || ''
  };

  const validationSchema = Yup.object({
    firstName: Yup.string().required('First name is required'),
    lastName: Yup.string().required('Last name is required'),
    email: Yup.string().email('Invalid email address').required('Email is required'),
    phoneNumber: Yup.string().matches(/^\d{10}$/, 'Phone number must be 10 digits')
  });

  const handleSubmit = (values, { setSubmitting, resetForm }) => {
    onSubmit(values);
    setSubmitting(false);
    resetForm();
  };

  return (
    <div className="customer-form">
      <h2>{customer ? 'Edit Customer' : 'Add New Customer'}</h2>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}
        enableReinitialize
      >
        {({ isSubmitting }) => (
          <Form>
            <div>
              <label htmlFor="firstName">First Name</label>
              <Field type="text" name="firstName" />
              <ErrorMessage name="firstName" component="div" className="error" />
            </div>
            <div>
              <label htmlFor="lastName">Last Name</label>
              <Field type="text" name="lastName" />
              <ErrorMessage name="lastName" component="div" className="error" />
            </div>
            <div>
              <label htmlFor="email">Email</label>
              <Field type="email" name="email" />
              <ErrorMessage name="email" component="div" className="error" />
            </div>
            <div>
              <label htmlFor="phoneNumber">Phone Number</label>
              <Field type="text" name="phoneNumber" />
              <ErrorMessage name="phoneNumber" component="div" className="error" />
            </div>
            <button type="submit" disabled={isSubmitting}>
              {customer ? 'Update' : 'Add'} Customer
            </button>
          </Form>
        )}
      </Formik>
    </div>
  );
};

export default CustomerForm;