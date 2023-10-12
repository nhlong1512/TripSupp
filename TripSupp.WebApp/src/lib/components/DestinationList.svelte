<script lang="ts">
	import { onMount } from 'svelte'
	import { loadDestinations } from '../../stores/destinationsStore'
	import destinationsStore from '../../stores/destinationsStore'
	import { deleteDestination, updateDestination } from '$lib/api'
	import type { IDestinationRequest } from '../../interfaces/destination/destinationRequest.interface'

	interface UpdatedTitles {
		[destinationId: string]: string
	}
	let destinationRequest: IDestinationRequest = { title: '' }
	let updatedTitles: UpdatedTitles = {}
	onMount(loadDestinations)
	$: destinations = $destinationsStore

	const handleDeleteDestination = async (id: string) => {
		try {
			await deleteDestination(id)
			await loadDestinations()
		} catch (error) {
			console.log('Error deleting destination: ', error)
		}
	}

	const handleUpdateDestination = async (id: string) => {
		destinationRequest.title = updatedTitles[id]
		try {
			await updateDestination(id, destinationRequest)
			await loadDestinations()
			updatedTitles[id] = ''
		} catch (error) {
			console.log('Error updating destination: ', error)
		}
	}
</script>

{#if destinations.length > 0}
	<ul>
		{#each destinations as destination (destination.destinationId)}
			<div class="divDestination">
				<li style="width:100px">
					<a href={`destination/${destination.destinationId}`}>{destination.title}</a>
				</li>
				<button on:click={() => handleDeleteDestination(destination.destinationId)}>
					Delete
				</button>
				<div style="display:flex;gap:20px">
					<input
						type="text"
						bind:value={updatedTitles[destination.destinationId]}
						placeholder="Enter updated title"
					/>
					<button on:click={() => handleUpdateDestination(destination.destinationId)}>Edit</button>
				</div>
			</div>
		{/each}
	</ul>
{:else}
	<p>Loading destinations...</p>
{/if}

<style>
	.divDestination {
		display: flex;
		justify-content: space-between;
		width: 500px;
		margin-bottom: 10px;
	}
</style>
