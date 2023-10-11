import type { IDestination } from '../interfaces/destination/destination.interface'

export const getAllDestinations = async (): Promise<IDestination[]> => {
	const url = `${import.meta.env.VITE_API_BASE_URL}/Destination/GetAllDestinations`
	console.log('url ------->', url)

	try {
		const response = await fetch(url)
		console.log(response)
		if (!response.ok) {
			throw new Error(`Error fetching destinations. Status: ${response.status}`)
		}
		const data = (await response.json()) as IDestination[]
		console.log('data ------->', data)
		return data
	} catch (error) {
		console.error(`Error fetching destinations: ${error}`)
		throw error
	}
}

export const getDestination = async (destinationId: string): Promise<IDestination> => {
	const url = `${import.meta.env.VITE_API_BASE_URL}/Destination/GetDestinationById/${destinationId}`
	console.log('url ------->', url)
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
