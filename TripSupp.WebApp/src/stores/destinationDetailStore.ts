import { writable, type Writable } from 'svelte/store'
import type { IDestination } from '../interfaces/destination/destination.interface'
import { getDestination } from '$lib/api'

const destinationDetailStore: Writable<IDestination> = writable()

export const loadDestinationDetail = async (id: string) => {
	const destination = await getDestination(id)
	destinationDetailStore.set(destination)
}

export default destinationDetailStore
