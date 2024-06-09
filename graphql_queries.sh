#!/bin/bash

# Base URL (update this to the correct URL and port if necessary)
BASE_URL="https://192.168.0.248:7198/graphql"

# Query: Get all cars
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ cars { carId model year licensePlate dailyRate status rentals { rentalId } } }"
}'

# Query: Get car by ID
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ carById(id: \"3d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\") { carId model year licensePlate dailyRate status rentals { rentalId } } }"
}'

# Query: Get all customers
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ customers { customerId firstName lastName email phoneNumber dateOfBirth driverLicenseNumber rentals { rentalId } } }"
}'

# Query: Get customer by ID
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ customerById(id: \"1d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\") { customerId firstName lastName email phoneNumber dateOfBirth driverLicenseNumber rentals { rentalId } } }"
}'

# Query: Get customer by Email
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ customerByEmail(email: \"example@example.com\") { customerId firstName lastName email phoneNumber dateOfBirth driverLicenseNumber rentals { rentalId } } }"
}'

# Query: Get all rentals
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ rentals { rentalId customerId carId startDate endDate totalCost customer { firstName } car { model } } }"
}'

# Query: Get rental by ID
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "{ rentalById(id: \"8d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\") { rentalId customerId carId startDate endDate totalCost customer { firstName } car { model } } }"
}'

# Mutation: Add car
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { addCar(car: { model: \"Toyota Corolla\", year: 2020, licensePlate: \"ABC123\", dailyRate: 50.0, status: \"Available\" }) { carId model } }"
}'

# Mutation: Update car
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { updateCar(car: { carId: \"3d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", model: \"Toyota Camry\", year: 2021, licensePlate: \"XYZ789\", dailyRate: 55.0, status: \"Unavailable\" }) { carId model } }"
}'

# Mutation: Delete car
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { deleteCar(id: \"3d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\") }"
}'

# Mutation: Add customer
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { addCustomer(customer: { firstName: \"Jan\", lastName: \"Kowalski\", email: \"jan.kowalski@example.com\", phoneNumber: \"123456789\", dateOfBirth: \"1985-01-01\", driverLicenseNumber: \"AB123456\" }) { customerId firstName } }"
}'

# Mutation: Update customer
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { updateCustomer(customer: { customerId: \"1d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", firstName: \"Anna\", lastName: \"Nowak\", email: \"anna.nowak@example.com\", phoneNumber: \"987654321\", dateOfBirth: \"1990-02-02\", driverLicenseNumber: \"CD789012\" }) { customerId firstName } }"
}'

# Mutation: Delete customer
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { deleteCustomer(id: \"1d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\") }"
}'

# Mutation: Add rental
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { addRental(rental: { customerId: \"1d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", carId: \"3d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", startDate: \"2023-05-01\", endDate: \"2023-05-10\", totalCost: 500.0 }) { rentalId startDate } }"
}'

# Mutation: Update rental
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { updateRental(rental: { rentalId: \"8d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", customerId: \"1d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", carId: \"3d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\", startDate: \"2023-06-01\", endDate: \"2023-06-15\", totalCost: 750.0 }) { rentalId startDate } }"
}'

# Mutation: Delete rental
curl -X POST $CURL_OPTS "$BASE_URL" -d '{
    "query": "mutation { deleteRental(id: \"8d9fcaeb-6e16-454d-a5ac-ca3ccb598c8a\") }"
}'
