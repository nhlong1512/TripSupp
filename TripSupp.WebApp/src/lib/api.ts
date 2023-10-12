import type { IDestination } from '../interfaces/destination/destination.interface'
import type { IDestinationRequest } from '../interfaces/destination/destinationRequest.interface'

const BASE_URL = import.meta.env.VITE_API_BASE_URL

export const getAllDestinations = async (): Promise<IDestination[]> => {
	const url = `${BASE_URL}/Destination/GetAllDestinations`

	try {
		const response = await fetch(url)
		if (!response.ok) {
			throw new Error(`Error fetching destinations. Status: ${response.status}`)
		}
		const data = (await response.json()) as IDestination[]
		return data
	} catch (error) {
		console.error(`Error fetching destinations: ${error}`)
		throw error
	}
}

export const getDestination = async (destinationId: string): Promise<IDestination> => {
	const url = `${BASE_URL}/Destination/GetDestinationById/${destinationId}`
	try {
		const response = await fetch(url)
		if (!response.ok) {
			throw new Error(`Error fetching destinations. Status: ${response.status}`)
		}
		const data = (await response.json()) as IDestination
		return data
	} catch (error) {
		console.error(`Error fetching destinations: ${error}`)
		throw error
	}
}

export const createDestination = async (
	destinationRequest: IDestinationRequest
): Promise<IDestination> => {
	const url = `${BASE_URL}/Destination/CreateDestination`
	try {
		const response = await fetch(url, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(destinationRequest)
		})
		if (!response.ok) {
			throw new Error(`Error fetching destinations. Status: ${response.status}`)
		}
		const data = (await response.json()) as IDestination
		return data
	} catch (error) {
		console.error(`Error fetching destinations: ${error}`)
		throw error
	}
}

export const deleteDestination = async (destinationId: string): Promise<void> => {
	const url = `${BASE_URL}/Destination/DeleteDestination/${destinationId}`
	try {
		const response = await fetch(url, {
			method: 'DELETE'
		})
		if (!response.ok) {
			throw new Error(`Error fetching destinations. Status: ${response.status}`)
		}
		return
	} catch (error) {
		console.error(`Error fetching destinations: ${error}`)
		throw error
	}
}

export const updateDestination = async (
	destinationId: string,
	destinationRequest: IDestinationRequest
): Promise<IDestination> => {
	const url = `${BASE_URL}/Destination/UpdateDestination?destinationId=${destinationId}`
	try {
		const response = await fetch(url, {
			method: 'PUT',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(destinationRequest)
		})
		if (!response.ok) {
			throw new Error(`Error fetching destinations. Status: ${response.status}`)
		}
		const data = (await response.json()) as IDestination
		return data
	} catch (error) {
		console.error(`Error fetching destinations: ${error}`)
		throw error
	}
}
