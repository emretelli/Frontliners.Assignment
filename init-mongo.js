db.createUser(
    {
        user: "admin",
        pwd: "Test123!",
        roles: [
            {
                role: "readWrite",
                db: "FrontlinersAssignment"
            }
        ]
    }
);
db.createCollection("Test");

db.Test.insert({
    "_id": "90700C24-1459-41AD-A16C-1A2756C7ADB0",
    "Name": "Admin",
    "Username": "admin",
    "Email": "admin@test.org"
});