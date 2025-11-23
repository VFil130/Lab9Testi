pm.test("Status code is 201", function () {
    pm.response.to.have.status(201);
});

pm.test("Response has correct structure", function () {
    const response = pm.response.json();
    pm.expect(response).to.have.keys(['id', 'name', 'username', 'email']);
});

pm.test("Created user data matches", function () {
    const response = pm.response.json();
    pm.expect(response.name).to.eql("John");
    pm.expect(response.username).to.eql("johnda");
    pm.expect(response.id).to.eql(11);
});