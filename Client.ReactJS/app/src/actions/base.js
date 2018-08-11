

export const SERVICE_BASE = "http://localhost:64510";

export function handleResponse(response) {
    console.log(response);
    if (response.ok) {
        return response.json();
    }
    else {
        let error = new Error(response.statusText);
        error.response = response;
        throw error;
    }
}