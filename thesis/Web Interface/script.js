// frontend/script.js
window.onload = () => {
    const form = document.getElementById('curriculumForm');
    const errorMessage = document.getElementById('error-message');
    const successMessage = document.getElementById('success-message');

    form.addEventListener('submit', async (event) => {
        event.preventDefault();
        // Form validation
        const formData = new FormData(form);
        if (!formData.get('title') || !formData.get('description')) {
            errorMessage.textContent = 'Please fill in all fields.';
            return;
        }

        // Submit form data
        try {
            const response = await fetch('/api/curriculum', {
                method: 'POST',
                body: formData
            });
            const data = await response.json();
            if (response.ok) {
                successMessage.textContent = data.message;
                form.reset();
            } else {
                errorMessage.textContent = data.message;
            }
        } catch (error) {
            console.error('Error submitting form:', error);
            errorMessage.textContent = 'An error occurred. Please try again later.';
        }
    });
};
