Para criar um frontend simples para interagir com essa API, podemos usar React como framework. Aqui está um exemplo básico de como isso pode ser feito:

### Passo 1: Instalação do React
Se ainda não tiver o React instalado, você pode criar um novo projeto com o comando:
```bash
npx create-react-app user-manager-frontend
```

### Passo 2: Criando Componentes

#### 1. **Componente `UserList` para exibir todos os usuários:**

```javascript
import React, { useState, useEffect } from 'react';

function UserList() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        fetch('/api/User')
            .then(response => response.json())
            .then(data => setUsers(data));
    }, []);

    return (
        <div>
            <h2>User List</h2>
            <ul>
                {users.map(user => (
                    <li key={user.id}>{user.name} - {user.email}</li>
                ))}
            </ul>
        </div>
    );
}

export default UserList;
```

#### 2. **Componente `UserDetail` para exibir detalhes de um usuário:**

```javascript
import React, { useState, useEffect } from 'react';

function UserDetail({ userId }) {
    const [user, setUser] = useState(null);

    useEffect(() => {
        fetch(`/api/User/${userId}`, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(response => response.json())
            .then(data => setUser(data));
    }, [userId]);

    if (!user) return <div>Loading...</div>;

    return (
        <div>
            <h2>User Details</h2>
            <p>Name: {user.name}</p>
            <p>Email: {user.email}</p>
        </div>
    );
}

export default UserDetail;
```

#### 3. **Componente `CreateUser` para criar um novo usuário:**

```javascript
import React, { useState } from 'react';

function CreateUser() {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        const user = { name, email, password };

        fetch('/api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        })
        .then(response => response.json())
        .then(data => {
            console.log('User created:', data);
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Create User</h2>
            <div>
                <label>Name:</label>
                <input type="text" value={name} onChange={(e) => setName(e.target.value)} required />
            </div>
            <div>
                <label>Email:</label>
                <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
            </div>
            <div>
                <label>Password:</label>
                <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
            </div>
            <button type="submit">Create</button>
        </form>
    );
}

export default CreateUser;
```

### Passo 3: Integrando os Componentes

Você pode criar um componente principal (`App.js`) para integrar esses componentes:

```javascript
import React, { useState } from 'react';
import UserList from './UserList';
import UserDetail from './UserDetail';
import CreateUser from './CreateUser';

function App() {
    const [selectedUserId, setSelectedUserId] = useState(null);

    return (
        <div>
            <h1>User Manager</h1>
            <CreateUser />
            <UserList />
            {selectedUserId && <UserDetail userId={selectedUserId} />}
        </div>
    );
}

export default App;
```

### Passo 4: Rodar o Projeto
Para rodar o projeto, use:
```bash
npm start
```

Isso vai iniciar um servidor de desenvolvimento e você poderá acessar o frontend no seu navegador.