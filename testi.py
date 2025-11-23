import requests
import pytest

BASE_URL = "https://jsonplaceholder.typicode.com"

class TestJSONPlaceholderAPI:
    
    def test_get_user(self):
        response = requests.get(f"{BASE_URL}/users/1")
        
        assert response.status_code == 200
        
        data = response.json()
        expected_keys = ['id', 'name', 'username', 'email', 'address', 'phone', 'website', 'company']
        for key in expected_keys:
            assert key in data
        
        assert data['id'] == 1
        assert isinstance(data['name'], str)
        assert '@' in data['email']
    
    def test_create_user(self):
        user_data = {
            "name": "John",
            "username": "johnda",
            "email": "john@example.com"
        }
        
        response = requests.post(f"{BASE_URL}/users", json=user_data)
        
        assert response.status_code == 201
        
        data = response.json()
        assert all(key in data for key in ['id', 'name', 'username', 'email'])
        
        assert data['name'] == user_data['name']
        assert data['username'] == user_data['username']
        assert data['id'] == 11
    
    def test_update_user(self):
        user_data = {
            "name": "John Smith", 
            "username": "johnsmith",
            "email": "johnsmith@example.com"
        }
        
        response = requests.put(f"{BASE_URL}/users/1", json=user_data)
        
        assert response.status_code == 200
        
        data = response.json()
        assert all(key in data for key in ['id', 'name', 'username', 'email'])
        
        assert data['name'] == user_data['name']
        assert data['username'] == user_data['username']
        assert data['id'] == 1

if __name__ == "__main__":
    pytest.main([__file__, "-v"])