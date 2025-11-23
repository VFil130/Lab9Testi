pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

pm.test("Response has correct structure", function () {
    const response = pm.response.json();
    pm.expect(response).to.have.keys(['id', 'name', 'username', 'email']);
});

pm.test("Updated user data matches", function () {
    const response = pm.response.json();
    pm.expect(response.name).to.eql("John Smith");
    pm.expect(response.username).to.eql("johnsmith");
    pm.expect(response.id).to.eql(1);
});