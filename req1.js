pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

pm.test("Response has correct structure", function () {
    const response = pm.response.json();
    pm.expect(response).to.have.keys(['id', 'name', 'username', 'email', 'address', 'phone', 'website', 'company']);
});

pm.test("User data is correct", function () {
    const response = pm.response.json();
    pm.expect(response.id).to.eql(1);
    pm.expect(response.name).to.be.a('string');
    pm.expect(response.email).to.include('@');
});