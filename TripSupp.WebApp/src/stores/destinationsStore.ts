import { writable, type Writable } from 'svelte/store'
import type { IDestination } from '../interfaces/destination/destination.interface'
import { getAllDestinations } from '$lib/api'

const destinationsStore: Writable<IDestination[]> = writable([])

export const loadDestinations = async () => {
	const destinations = await getAllDestinations()
	destinationsStore.set(destinations)
}

export default destinationsStore
