<script lang="ts">
	import { createDestination } from '$lib/api'
	import DestinationList from '$lib/components/DestinationList.svelte'
	import type { IDestinationRequest } from '../../interfaces/destination/destinationRequest.interface'
	import { loadDestinations } from '../../stores/destinationsStore'

	let destinationTitle = ''

	const handleCreateDestination = async () => {
		let destinationRequest: IDestinationRequest = { title: '' }
		destinationRequest.title = destinationTitle
		try {
			const result = await createDestination(destinationRequest)
			await loadDestinations()
			destinationTitle = ''
		} catch (error) {
			console.log('Error creating destination: ', error)
		}
	}
</script>

<div>
	<h1>List Destinations</h1>
	<div>
		<DestinationList />
	</div>

	<div>
		<input bind:value={destinationTitle} type="text" placeholder="Enter new destination" />
		<button on:click={handleCreateDestination}> Create Destination </button>
	</div>
</div>
