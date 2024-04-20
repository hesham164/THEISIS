// script.js
window.onload = () => {
    fetch('/api/curriculum')
        .then(response => response.json())
        .then(data => {
            // Process curriculum data and load into AR environment
        })
        .catch(error => console.error('Error fetching curriculum:', error));
};
